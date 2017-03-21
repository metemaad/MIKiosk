using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MIKiosk.BusinessLayer.InfraStructure;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.Model;
using NHibernate.Linq;
using Brushes = System.Windows.Media.Brushes;

namespace MIKiosk.TV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   

        public partial class MainWindow
        {


            const double Gap = 100.0; // pixel gap between each TextBlock
            const int TimerInterval = 16; // number of ms between timer ticks. 16 is near 1/60th second, for smoother updates on LCD displays
            const double MoveAmount = 2.5; // number of pixels to move each timer tick. 1 - 1.5 is ideal, any higher will introduce judders

            private LinkedList<TextBlock> textBlocks = new LinkedList<TextBlock>();
            private Timer timer = new Timer();


            private readonly IEnumerable<Product> _productinfos;
            private IEnumerator<Product> _enumerator;


            private void RefreshExecuted(object sender, ExecutedRoutedEventArgs e)
            {
                Application.Current.Shutdown();
            }

            private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {

                e.CanExecute = true;
                e.Handled = true;
            }
            public MainWindow()
            {
                InitializeComponent();

                _productinfos = DataAccess.NhSession.Query<Product>();


                initializaClock();

                canvas1.Width = SystemParameters.PrimaryScreenWidth;

                DPTitle.Width = SystemParameters.PrimaryScreenWidth - 300;
                DPTitle.Height = 40;

                txbReceta.Height = SystemParameters.PrimaryScreenHeight - 400;

                dockPanel2.Width = SystemParameters.PrimaryScreenWidth - 300;
                dockPanel2.Height = SystemParameters.PrimaryScreenHeight - 150;
                dockPanel4.Height = SystemParameters.PrimaryScreenHeight - 400;
                image.Height = dockPanel2.Height - 50;
                image.Width = dockPanel2.Width;
                image.StretchDirection = StretchDirection.Both;
                Loaded += MainWindowLoaded;


                /*from file in System.IO.Directory.GetFiles(imgdir, "*.png")
                          orderby file
                          let uri = new Uri(file, UriKind.Absolute)
                          select new BitmapImage(uri);

                 */
                AddTextBlock("Order Number 210 is Ready.");
                AddTextBlock("Order Number 412 is in Stock, 5 Item of 9 is Ready.");
                AddTextBlock("Order Number 309 is Ready.");
                AddTextBlock("Order Number 412 is in Packageing.");
                AddTextBlock("Order Number 431 is in Packageing.");
                AddTextBlock("Order Number 243 is Ready.");
                AddTextBlock("Order Number 310 is Ready.");
                AddTextBlock("Order Number 315 has Problem Please come to ATM to Solve the problem.");
                AddTextBlock("Order Number 512 is Ready.");
                myScroll.LineUp(); myScroll.LineUp();

                canvas1.Dispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(delegate(Object state)
                {
                    var node = textBlocks.First;

                    while (node != null)
                    {
                        if (node.Previous != null)
                        {
                            Canvas.SetLeft(node.Value, Canvas.GetLeft(node.Previous.Value) + node.Previous.Value.ActualWidth + Gap);
                        }
                        else
                        {
                            Canvas.SetLeft(node.Value, canvas1.Width + Gap);
                        }

                        node = node.Next;
                    }

                    return null;

                }), null);

                timer.Interval = TimerInterval;
                timer.Elapsed += TimerElapsed;
                timer.Start();


            }

            private void initializaClock()
            {
                //MDCalendar mdCalendar = new MDCalendar();
                DateTime date = DateTime.Now;
                TimeZone time = TimeZone.CurrentTimeZone;
                TimeSpan difference = time.GetUtcOffset(date);
                //uint currentTime = mdCalendar.Time() + (uint)difference.TotalSeconds;
                //persianCalendar.Content = mdCalendar.Date("Y/m/D  W", currentTime, true);
                christianityCalendar.Content = DateTime.Now.ToString(); //mdCalendar.Date("P Z/e/d", currentTime, false);

                timer.Elapsed += timer_Elapsed;
                timer.Enabled = true;
            }

            private void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    secondHand.Angle = DateTime.Now.Second * 6;
                    minuteHand.Angle = DateTime.Now.Minute * 6;
                    hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
                }));
            }

            private void MainWindowLoaded(object sender, RoutedEventArgs e)
            {
                var dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1800) };
                dispatcherTimer.Tick += TimerTick;
                dispatcherTimer.Start();
            }

            private void TimerTick(object sender, EventArgs e)
            {
                if (_enumerator == null || !_enumerator.MoveNext())
                {
                    _enumerator = _productinfos.GetEnumerator();
                    _enumerator.MoveNext();


                }

                var i = new ImageFile();
                using (i)
                {


                    
                    var imgbrush = new BitmapImage();
                    imgbrush.BeginInit();
                    imgbrush.StreamSource = ConvertImageToMemoryStream(_enumerator.Current.ProductImage);
                    imgbrush.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    imgbrush.EndInit();
                    image.Source = imgbrush;
                }
                Title.Content = _enumerator.Current.ProductName;
                txbReceta.Text = _enumerator.Current.ProductDescription;
                //Message.Content = _enumerator.Current.ProductDescription ;
            }
            public static MemoryStream ConvertImageToMemoryStream(System.Drawing.Image img)
            {
                var ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms;
            }

            public void dlfile(string s, string f)
            {
                WebClient req = new WebClient();
                req.Credentials = new NetworkCredential("mhm", "760614811");
                byte[] filedata = req.DownloadData(s + "/" + f);
                FileStream file = File.Create("c:\\a\\" + f);
                file.Write(filedata, 0, filedata.Length);
                file.Close();
            }

            public static Bitmap LoadPicture(string url)
            {
                System.Net.HttpWebRequest wreq;
                System.Net.HttpWebResponse wresp;
                Stream mystream;
                Bitmap bmp;

                bmp = null;
                mystream = null;
                wresp = null;
                try
                {
                    wreq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                    wreq.AllowWriteStreamBuffering = true;

                    wresp = (System.Net.HttpWebResponse)wreq.GetResponse();

                    if ((mystream = wresp.GetResponseStream()) != null)
                        bmp = new Bitmap(mystream);
                }
                catch
                {
                    // Do nothing... 
                }
                finally
                {
                    if (mystream != null)
                        mystream.Close();

                    if (wresp != null)
                        wresp.Close();
                }

                return (bmp);
            }


            void TimerElapsed(object sender, ElapsedEventArgs e)
            {
                canvas1.Dispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(delegate(Object state)
                {
                    var node = textBlocks.First;
                    var lastNode = textBlocks.Last;

                    while (node != null)
                    {
                        var newLeft = Canvas.GetLeft(node.Value) - MoveAmount;

                        if (newLeft < (0 - (node.Value.ActualWidth + Gap)))
                        {
                            textBlocks.Remove(node);

                            var lastNodeLeftPos = Canvas.GetLeft(lastNode.Value);

                            textBlocks.AddLast(node);

                            if ((lastNodeLeftPos + lastNode.Value.ActualWidth + Gap) > canvas1.Width) // Last element is offscreen
                            {
                                newLeft = lastNodeLeftPos + lastNode.Value.ActualWidth + Gap;
                            }
                            else
                            {
                                newLeft = canvas1.Width + Gap;
                            }
                        }

                        Canvas.SetLeft(node.Value, newLeft);

                        node = node == lastNode ? null : node.Next;
                    }

                    return null;

                }), null);
            }

            void AddTextBlock(string text)
            {
                var tb = new TextBlock { Text = text, FontSize = 28, FontWeight = FontWeights.Normal, Foreground = Brushes.Navy };

                canvas1.Children.Add(tb);

                Canvas.SetTop(tb, 20);
                Canvas.SetLeft(tb, -999);

                textBlocks.AddLast(tb);
            }
        }

    }

