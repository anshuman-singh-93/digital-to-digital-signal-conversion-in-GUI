using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigToDig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> msg_bit = new List<string>();
        public double last_x1 = 0;
        public double last_x2 = 50;
        public double last_y1 = 15;
        public double last_y2 = 15;

        public double nrzI_last_x1 = 0;
        public double nrzI_last_x2 = 50;
        public double nrzI_last_y1 = 15;
        public double nrzI_last_y2 = 15;
        public Label nrzl_label;
        public Label nrzI_label;

        public static double line_margin = 0;
        public string last_bit;
        public string current_bit;
        public bool nrz_l_started = false;
        public bool nrz_I_started = false;
        Line last_nrzl_linex_drawn;
        Line last_nrzl_liney_drawn;

        Line last_nrzI_linex_drawn;
        Line last_nrzI_liney_drawn;

        Line last_bipolar_linex_drawn;
        Line last_bipolar_liney_drawn;


        public double last_bipolar_x1 = 0;
        public double last_bipolar_x2= 50;
        public double last_bipolar_y1 = 15;
        public double last_bipolar_y2 = 15;
        public bool bipolar_started = false;
        public string last_bipolar_one = "high";


        //psuedo
        Line last_psuedo_t_linex_drawn;
        Line last_psuedo_t_liney_drawn;


        public double last_psuedo_t_x1 = 0;
        public double last_psuedo_t_x2 = 50;
        public double last_psuedo_t_y1 = 15;
        public double last_psuedo_t_y2 = 15;
        public bool psuedo_t_started = false;
        public string last_psuedo_t_one = "high";

        //manchester


        Line last_man_linex_drawn;


        public double last_man_x1 = 0;
        public double last_man_x2 = 50;
        public double last_man_y1 = 15;
        public double last_man_y2 = 15;
        public bool man_started = false;
        public string last_man_bit = "0";
        List<Line> man_last_line = new List<Line>();



        public static int item_count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }



        public void Drawing_nrzi_label(Line line)
        {
            Label lb = new Label();
            lb.Width = 50;
            lb.Height = 30;
            lb.Content = msg_bit[item_count];
            canvas_nrzi.Children.Add(lb);

            Canvas.SetLeft(lb, line.X1 + 20);
            Canvas.SetTop(lb, -10);
        }
        public void Drawing_nrzl_label(Line line)
        {
            Label lb = new Label();
            lb.Width = 50;
            lb.Height = 30;
            lb.Content = msg_bit[item_count];
            canvas_nrzl.Children.Add(lb);

            Canvas.SetLeft(lb, line.X1 + 20);
            Canvas.SetTop(lb, -10);
        }
        public void Drawing_bipolar_label(Line line)
        {
            Label lb = new Label();
            lb.Width = 50;
            lb.Height = 30;
            lb.Content = msg_bit[item_count];
            canvas_bipolar.Children.Add(lb);

            Canvas.SetLeft(lb, line.X1+20 );
            Canvas.SetTop(lb, -10);
        }

        public void Drawing_psuedo_t_label(Line line)
        {
            Label lb = new Label();
            lb.Width = 50;
            lb.Height = 30;
            lb.Content = msg_bit[item_count];
            canvas_psuedo.Children.Add(lb);

            Canvas.SetLeft(lb, line.X1 + 20);
            Canvas.SetTop(lb, -10);
        }
        public void Drawing_man_label(Line line)
        {
            Label lb = new Label();
            lb.Width = 50;
            lb.Height = 30;
            lb.Content = msg_bit[item_count];
            canvas_man.Children.Add(lb);

            Canvas.SetLeft(lb, line.X1-9);
            Canvas.SetTop(lb, -10);
        }


        public void draw_nrzl(double x1, double x2)
        {
            Line line = new Line();
            Line line2 = new Line();

            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 4;
            line.Stroke = System.Windows.Media.Brushes.Green;
            line.X1 = x1;
            line.X2 = x2;
            if (current_bit == "0")
            {
                line.Y1 = 15;
                line.Y2 = 15;
            }
            else
            {
                line.Y1 = 65;
                line.Y2 = 65;
            }
            last_x1 = line.X1;
            last_x2 = line.X2;

            if ((current_bit == "1" && last_bit == "0") || (current_bit == "0" && last_bit == "1"))
            {
                line2.Visibility = System.Windows.Visibility.Visible;
                line2.StrokeThickness = 4;
                line2.Stroke = System.Windows.Media.Brushes.Green;
                line2.X1 = x1;
                line2.X2 = x1;
                line2.Y1 = 15;
                line2.Y2 = 65;
                canvas_nrzl.Children.Add(line2);

            }
            canvas_nrzl.Children.Add(line);
            Drawing_nrzl_label(line);


            if (nrz_l_started)
            {
                last_nrzl_linex_drawn.Stroke = System.Windows.Media.Brushes.Black;
                last_nrzl_liney_drawn.Stroke = System.Windows.Media.Brushes.Black;

            }
            last_nrzl_linex_drawn = line;
            last_nrzl_liney_drawn = line2;


            nrz_l_started = true;

        }

        public void draw_nrzI(double x1, double x2)
        {
            if (!nrz_I_started)
            {
                Line line = new Line();
                line.Visibility = System.Windows.Visibility.Visible;
                line.StrokeThickness = 4;
                line.Stroke = System.Windows.Media.Brushes.Green;

                line.X1 = x1;
                line.X2 = x2;

                if (current_bit == "0")
                {
                    line.Y1 = 15;
                    line.Y2 = 15;
                }

                else
                {
                    line.Y1 = 65;
                    line.Y2 = 65;
                }
                nrzI_last_y1 = line.Y1;
                nrzI_last_y2 = line.Y2;
                nrzI_last_x1 = line.X1;
                nrzI_last_x2 = line.X2;

                canvas_nrzi.Children.Add(line);
                last_nrzI_linex_drawn = line;

                nrz_I_started = true;

                Drawing_nrzi_label(line);
            }

            else
            {
                if (current_bit == "0")
                {
                    Line line = new Line();
                    line.Visibility = System.Windows.Visibility.Visible;
                    line.StrokeThickness = 4;
                    line.Stroke = System.Windows.Media.Brushes.Green;

                    line.X1 = x1;
                    line.X2 = x2;
                    nrzI_last_x1 = line.X1;
                    nrzI_last_x2 = line.X2;
                    line.Y1 = nrzI_last_y1;
                    line.Y2 = nrzI_last_y2;
                    nrzI_last_y1 = line.Y1;
                    nrzI_last_y2 = line.Y2;
                    canvas_nrzi.Children.Add(line);
                    last_nrzI_linex_drawn.Stroke = Brushes.Black;
                    last_nrzI_linex_drawn = line;
                    if (last_nrzI_liney_drawn != null)
                        last_nrzI_liney_drawn.Stroke = Brushes.Black;

                    Drawing_nrzi_label(line);




                }

                if (current_bit == "1")
                {
                    if (nrzI_last_y1 == 15 && nrzI_last_y2 == 15)
                    {      //draw horrizontal line

                        Line line = new Line();
                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 65;
                        line.Y2 = 65;
                        nrzI_last_y1 = 65;
                        nrzI_last_y2 = 65;
                        canvas_nrzi.Children.Add(line);
                        last_nrzI_linex_drawn.Stroke = Brushes.Black;

                        last_nrzI_linex_drawn = line;

                        //draw vertical line

                        Line line2 = new Line();
                        line2.Visibility = System.Windows.Visibility.Visible;
                        line2.StrokeThickness = 4;
                        line2.Stroke = System.Windows.Media.Brushes.Green;
                        line2.X1 = x1;
                        line2.X2 = x1;
                        line2.Y1 = 15;
                        line2.Y2 = 65;
                        canvas_nrzi.Children.Add(line2);
                        if (last_nrzI_liney_drawn != null)
                            last_nrzI_liney_drawn.Stroke = Brushes.Black;

                        last_nrzI_liney_drawn = line2;

                        nrzI_last_x1 = x1;
                        nrzI_last_x2 = x2;

                        Drawing_nrzi_label(line);




                    }

                    else if (nrzI_last_y1 == 65 && nrzI_last_y2 == 65)
                    {
                        //draw horrizontal line
                        Line line = new Line();
                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 15;
                        line.Y2 = 15;
                        nrzI_last_y1 = 15;
                        nrzI_last_y2 = 15;
                        canvas_nrzi.Children.Add(line);
                        last_nrzI_linex_drawn.Stroke = Brushes.Black;

                        last_nrzI_linex_drawn = line;

                        //draw vertical line

                        Line line2 = new Line();
                        line2.Visibility = System.Windows.Visibility.Visible;
                        line2.StrokeThickness = 4;
                        line2.Stroke = System.Windows.Media.Brushes.Green;
                        line2.X1 = x1;
                        line2.X2 = x1;
                        line2.Y1 = 15;
                        line2.Y2 = 65;
                        canvas_nrzi.Children.Add(line2);
                        if (last_nrzI_liney_drawn != null)
                            last_nrzI_liney_drawn.Stroke = Brushes.Black;

                        last_nrzI_liney_drawn = line2;

                        nrzI_last_x1 = x1;
                        nrzI_last_x2 = x2;

                        Drawing_nrzi_label(line);

                    }


                }
            }
        }

        public void draw_bipolar(double x1, double x2)
        {
            if(!bipolar_started)
            {
                Line line = new Line();
                Line line2 = new Line();

                line.Visibility = System.Windows.Visibility.Visible;
                line.StrokeThickness = 4;
                line.Stroke = System.Windows.Media.Brushes.Green;
                line.X1 = x1;
                line.X2 = x2;
                last_bipolar_x1 = line.X1;
                last_bipolar_x2 = line.X2;
                last_bipolar_linex_drawn = line;
                if (current_bit=="0")
                {
                    line.Y1 = 40;
                    line.Y2 = 40;
                   
                    last_bipolar_y1 = line.Y1;
                    last_bipolar_y2 = line.Y2;
                    canvas_bipolar.Children.Add(line);

                    Drawing_bipolar_label(line);



                }

                else
                {
                    line.Y1 = 65;
                    line.Y2 = 65;
                    last_bipolar_y1 = line.Y1;
                    last_bipolar_y2 = line.Y2;
                    canvas_bipolar.Children.Add(line);
                    Drawing_bipolar_label(line);
                    last_bipolar_one = "low";

                }
            }

            else
            {
                if( current_bit=="0")
                {
                    if (last_bipolar_y1 == 15 && last_bipolar_y2 == 15)
                    {
                        // if so then draw two line . i.e vertical line also
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 40;
                        line.Y2 = 40;
                        last_bipolar_y1 = line.Y1;
                        last_bipolar_y2 = line.Y2;
                        canvas_bipolar.Children.Add(line);
                        last_bipolar_linex_drawn.Stroke = Brushes.Black;
                        // vertical 
                        Line line2 = new Line();
                        line2.Visibility = System.Windows.Visibility.Visible;
                        line2.StrokeThickness = 4;
                        line2.Stroke = System.Windows.Media.Brushes.Green;
                        line2.X1 = x1;
                        line2.X2 = x1;
                        line2.Y1 = 15;
                        line2.Y2 = 40;
                        canvas_bipolar.Children.Add(line2);
                        Drawing_bipolar_label(line);
                        if (last_bipolar_liney_drawn != null)
                            last_bipolar_liney_drawn.Stroke = Brushes.Black;
                        last_bipolar_x1 = line.X1;
                        last_bipolar_x2 = line.X2;
                        last_bipolar_linex_drawn = line;
                        last_bipolar_liney_drawn = line2;

                    }

                    else if (last_bipolar_y1 == 40 && last_bipolar_y2 == 40)
                    {
                        // if so then draw one line . i.e horrizontal line only
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 40;
                        line.Y2 = 40;
                        last_bipolar_y1 = line.Y1;
                        last_bipolar_y2 = line.Y2;
                        canvas_bipolar.Children.Add(line);
                       
                        Drawing_bipolar_label(line);

                        last_bipolar_x1 = line.X1;
                        last_bipolar_x2 = line.X2;
                        last_bipolar_linex_drawn.Stroke = Brushes.Black;

                        last_bipolar_linex_drawn = line;


                    }

                    else if (last_bipolar_y1 == 65 && last_bipolar_y2 == 65)
                    {

                        // if so then draw two line . i.e vertical line also
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 40;
                        line.Y2 = 40;
                        last_bipolar_y1 = line.Y1;
                        last_bipolar_y2 = line.Y2;
                        canvas_bipolar.Children.Add(line);
                        last_bipolar_linex_drawn.Stroke = Brushes.Black;
                        // vertical 
                        Line line2 = new Line();
                        line2.Visibility = System.Windows.Visibility.Visible;
                        line2.StrokeThickness = 4;
                        line2.Stroke = System.Windows.Media.Brushes.Green;
                        line2.X1 = x1;
                        line2.X2 = x1;
                        line2.Y1 = 65;
                        line2.Y2 = 40;
                        canvas_bipolar.Children.Add(line2);
                        Drawing_bipolar_label(line);
                        if (last_bipolar_liney_drawn != null)
                            last_bipolar_liney_drawn.Stroke = Brushes.Black;
                        last_bipolar_x1 = line.X1;
                        last_bipolar_x2 = line.X2;
                        last_bipolar_linex_drawn = line;
                        last_bipolar_liney_drawn = line2;





                    }
                }

                else if (current_bit == "1")
                {
                    //horrizontal

                    if (last_bipolar_one == "low")
                    {
                        //horrizontal
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 15;
                        line.Y2 = 15;
                      
                        canvas_bipolar.Children.Add(line);
                        last_bipolar_linex_drawn.Stroke = Brushes.Black;
                        last_bipolar_linex_drawn = line;


                        if (last_bipolar_y1==40 && last_bipolar_y2==40 )
                        {
                            //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 40;
                            line2.Y2 = 15;
                            canvas_bipolar.Children.Add(line2);
                            if(last_bipolar_liney_drawn!=null)
                            {
                                last_bipolar_liney_drawn.Stroke = Brushes.Black;
                                last_bipolar_liney_drawn = line2;

                            }

                        }
                        else if(last_bipolar_y1==65 && last_bipolar_y2==65)
                        { //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 65;
                            line2.Y2 = 15;
                            canvas_bipolar.Children.Add(line2);
                            if (last_bipolar_liney_drawn != null)
                            {
                                last_bipolar_liney_drawn.Stroke = Brushes.Black;
                                last_bipolar_liney_drawn = line2;

                            }

                        }
                        last_bipolar_x1 = line.X1;
                        last_bipolar_x2 = line.X2;
                        last_bipolar_y1 = line.Y1;
                        last_bipolar_y2 = line.Y2;
                        Drawing_bipolar_label(line);
                        last_bipolar_one = "high";
                    }

                    else if (last_bipolar_one == "high")
                    {
                        //horrizontal
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 65;
                        line.Y2 = 65;

                        canvas_bipolar.Children.Add(line);

                        last_bipolar_linex_drawn.Stroke = Brushes.Black;
                        last_bipolar_linex_drawn = line;

                        if (last_bipolar_y1 == 40 && last_bipolar_y2 == 40)
                        {
                            //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 40;
                            line2.Y2 = 65;
                            canvas_bipolar.Children.Add(line2);
                            if (last_bipolar_liney_drawn != null)
                            {
                                last_bipolar_liney_drawn.Stroke = Brushes.Black;
                                last_bipolar_liney_drawn = line2;

                            }


                        }

                        else if (last_bipolar_y1 == 15 && last_bipolar_y2 == 15)
                        {
                            //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 15;
                            line2.Y2 = 65;
                            canvas_bipolar.Children.Add(line2);
                            if (last_bipolar_liney_drawn != null)
                            {
                                last_bipolar_liney_drawn.Stroke = Brushes.Black;
                                last_bipolar_liney_drawn = line2;

                            }

                        }


                        last_bipolar_x1 = line.X1;
                        last_bipolar_x2 = line.X2;
                        last_bipolar_y1 = line.Y1;
                        last_bipolar_y2 = line.Y2;
                        Drawing_bipolar_label(line);
                        last_bipolar_one = "low";
                    }

                }


            }


            bipolar_started = true;
        }


        public void draw_psuedo_t(double x1, double x2)
        {
            if (!psuedo_t_started)
            {
                Line line = new Line();
                Line line2 = new Line();

                line.Visibility = System.Windows.Visibility.Visible;
                line.StrokeThickness = 4;
                line.Stroke = System.Windows.Media.Brushes.Green;
                line.X1 = x1;
                line.X2 = x2;
                last_psuedo_t_x1 = line.X1;
                last_psuedo_t_x2 = line.X2;
                last_psuedo_t_linex_drawn = line;
                if (current_bit == "1")
                {
                    line.Y1 = 40;
                    line.Y2 = 40;

                    last_psuedo_t_y1 = line.Y1;
                    last_psuedo_t_y2 = line.Y2;
                    canvas_psuedo.Children.Add(line);

                    Drawing_psuedo_t_label(line);



                }

                else
                {
                    line.Y1 = 65;
                    line.Y2 = 65;
                    last_psuedo_t_y1 = line.Y1;
                    last_psuedo_t_y2 = line.Y2;
                    canvas_psuedo.Children.Add(line);
                    Drawing_psuedo_t_label(line);
                    last_psuedo_t_one = "low";

                }
            }

            else
            {
                if (current_bit == "1")
                {
                    if (last_psuedo_t_y1 == 15 && last_psuedo_t_y2 == 15)
                    {
                        // if so then draw two line . i.e vertical line also
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 40;
                        line.Y2 = 40;
                        last_psuedo_t_y1 = line.Y1;
                        last_psuedo_t_y2 = line.Y2;
                        canvas_psuedo.Children.Add(line);
                        last_psuedo_t_linex_drawn.Stroke = Brushes.Black;
                        // vertical 
                        Line line2 = new Line();
                        line2.Visibility = System.Windows.Visibility.Visible;
                        line2.StrokeThickness = 4;
                        line2.Stroke = System.Windows.Media.Brushes.Green;
                        line2.X1 = x1;
                        line2.X2 = x1;
                        line2.Y1 = 15;
                        line2.Y2 = 40;
                        canvas_psuedo.Children.Add(line2);
                        Drawing_psuedo_t_label(line);
                        if (last_psuedo_t_liney_drawn != null)
                            last_psuedo_t_liney_drawn.Stroke = Brushes.Black;
                        last_psuedo_t_x1 = line.X1;
                        last_psuedo_t_x2 = line.X2;
                        last_psuedo_t_linex_drawn = line;
                        last_psuedo_t_liney_drawn = line2;

                    }

                    else if (last_psuedo_t_y1 == 40 && last_psuedo_t_y2 == 40)
                    {
                        // if so then draw one line . i.e horrizontal line only
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 40;
                        line.Y2 = 40;
                        last_psuedo_t_y1 = line.Y1;
                        last_psuedo_t_y2 = line.Y2;
                        canvas_psuedo.Children.Add(line);

                        Drawing_psuedo_t_label(line);

                        last_psuedo_t_x1 = line.X1;
                        last_psuedo_t_x2 = line.X2;
                        last_psuedo_t_linex_drawn.Stroke = Brushes.Black;

                        last_psuedo_t_linex_drawn = line;


                    }

                    else if (last_psuedo_t_y1 == 65 && last_psuedo_t_y2 == 65)
                    {

                        // if so then draw two line . i.e vertical line also
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 40;
                        line.Y2 = 40;
                        last_psuedo_t_y1 = line.Y1;
                        last_psuedo_t_y2 = line.Y2;
                        canvas_psuedo.Children.Add(line);
                        last_psuedo_t_linex_drawn.Stroke = Brushes.Black;
                        // vertical 
                        Line line2 = new Line();
                        line2.Visibility = System.Windows.Visibility.Visible;
                        line2.StrokeThickness = 4;
                        line2.Stroke = System.Windows.Media.Brushes.Green;
                        line2.X1 = x1;
                        line2.X2 = x1;
                        line2.Y1 = 65;
                        line2.Y2 = 40;
                        canvas_psuedo.Children.Add(line2);
                        Drawing_psuedo_t_label(line);
                        if (last_psuedo_t_liney_drawn != null)
                            last_psuedo_t_liney_drawn.Stroke = Brushes.Black;
                        last_psuedo_t_x1 = line.X1;
                        last_psuedo_t_x2 = line.X2;
                        last_psuedo_t_linex_drawn = line;
                        last_psuedo_t_liney_drawn = line2;





                    }
                }

                else if (current_bit == "0")
                {
                    //horrizontal

                    if (last_psuedo_t_one == "low")
                    {
                        //horrizontal
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 15;
                        line.Y2 = 15;

                        canvas_psuedo.Children.Add(line);
                        last_psuedo_t_linex_drawn.Stroke = Brushes.Black;
                        last_psuedo_t_linex_drawn = line;


                        if (last_psuedo_t_y1 == 40 && last_psuedo_t_y2 == 40)
                        {
                            //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 40;
                            line2.Y2 = 15;
                            canvas_psuedo.Children.Add(line2);
                            if (last_psuedo_t_liney_drawn != null)
                            {
                                last_psuedo_t_liney_drawn.Stroke = Brushes.Black;
                                last_psuedo_t_liney_drawn = line2;

                            }

                        }
                        else if (last_psuedo_t_y1 == 65 && last_psuedo_t_y2 == 65)
                        { //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 65;
                            line2.Y2 = 15;
                            canvas_psuedo.Children.Add(line2);
                            if (last_psuedo_t_liney_drawn != null)
                            {
                                last_psuedo_t_liney_drawn.Stroke = Brushes.Black;
                                last_psuedo_t_liney_drawn = line2;

                            }

                        }
                        last_psuedo_t_x1 = line.X1;
                        last_psuedo_t_x2 = line.X2;
                        last_psuedo_t_y1 = line.Y1;
                        last_psuedo_t_y2 = line.Y2;
                        Drawing_psuedo_t_label(line);
                        last_psuedo_t_one = "high";
                    }

                    else if (last_psuedo_t_one == "high")
                    {
                        //horrizontal
                        Line line = new Line();

                        line.Visibility = System.Windows.Visibility.Visible;
                        line.StrokeThickness = 4;
                        line.Stroke = System.Windows.Media.Brushes.Green;
                        line.X1 = x1;
                        line.X2 = x2;
                        line.Y1 = 65;
                        line.Y2 = 65;

                        canvas_psuedo.Children.Add(line);

                        last_psuedo_t_linex_drawn.Stroke = Brushes.Black;
                        last_psuedo_t_linex_drawn = line;

                        if (last_psuedo_t_y1 == 40 && last_psuedo_t_y2 == 40)
                        {
                            //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 40;
                            line2.Y2 = 65;
                            canvas_psuedo.Children.Add(line2);
                            if (last_psuedo_t_liney_drawn != null)
                            {
                                last_psuedo_t_liney_drawn.Stroke = Brushes.Black;
                                last_psuedo_t_liney_drawn = line2;

                            }


                        }

                        else if (last_psuedo_t_y1 == 15 && last_psuedo_t_y2 == 15)
                        {
                            //v
                            Line line2 = new Line();
                            line2.Visibility = System.Windows.Visibility.Visible;
                            line2.StrokeThickness = 4;
                            line2.Stroke = System.Windows.Media.Brushes.Green;
                            line2.X1 = x1;
                            line2.X2 = x1;
                            line2.Y1 = 15;
                            line2.Y2 = 65;
                            canvas_psuedo.Children.Add(line2);
                            if (last_psuedo_t_liney_drawn != null)
                            {
                                last_psuedo_t_liney_drawn.Stroke = Brushes.Black;
                                last_psuedo_t_liney_drawn = line2;

                            }

                        }


                        last_psuedo_t_x1 = line.X1;
                        last_psuedo_t_x2 = line.X2;
                        last_psuedo_t_y1 = line.Y1;
                        last_psuedo_t_y2 = line.Y2;
                        Drawing_psuedo_t_label(line);
                        last_psuedo_t_one = "low";
                    }

                }


            }


            psuedo_t_started = true;
        }


        public void draw_man(double x1, double x2)
        {
            
            if (!man_started)
            {
                Line line = new Line();
                line.Visibility = System.Windows.Visibility.Visible;
                line.StrokeThickness = 4;
                line.Stroke = System.Windows.Media.Brushes.Green;


                //left arrow
                Line line2 = new Line();
                line2.Visibility = System.Windows.Visibility.Visible;
                line2.StrokeThickness = 2;
                line2.Stroke = System.Windows.Media.Brushes.Green;

                //right arrow
                Line line3 = new Line();
                line3.Visibility = System.Windows.Visibility.Visible;
                line3.StrokeThickness = 2;
                line3.Stroke = System.Windows.Media.Brushes.Green;


                //x1 = x1 + 20;
                //x2 = x2 + 20;
                line.X1 = x1;
                line.X2 = x1;

                if (current_bit == "0")
                {
                    line.Y1 = 15;
                    line.Y2 = 65;

                    line2.X1 = x1 - 10;
                    line2.X2 = x1;
                    line2.Y1 = line.Y2 - 10;
                    line2.Y2 = line.Y2;

                    line3.X1 = x1;
                    line3.X2 = x1 + 10;
                    line3.Y1 = line.Y2;
                    line3.Y2 = line.Y2 - 10;

                }

                else
                {
                    line.Y1 = 65;
                    line.Y2 = 15;
                    line2.X1 = x1;
                    line2.X2 = x1 - 10;
                    line2.Y1 = line.Y2;
                    line2.Y2 = line.Y2 + 10;

                    line3.X1 = x1;
                    line3.X2 = x1 + 10;
                    line3.Y1 = line.Y2;
                    line3.Y2 = line.Y2 + 10;
                }
            


                last_man_y1 = line.Y1;
                last_man_y2 = line.Y2;
                last_man_x1 = line.X1;
                last_man_x2 = line.X1;

                canvas_man.Children.Add(line);
                canvas_man.Children.Add(line2);
                canvas_man.Children.Add(line3);
                man_last_line.Add(line);
                man_last_line.Add(line2);
                man_last_line.Add(line3);

                last_man_linex_drawn = line;

                man_started = true;
                last_man_bit = current_bit;
                Drawing_man_label(line);
            }

            else
            {

                Line line = new Line();
                line.Visibility = System.Windows.Visibility.Visible;
                line.StrokeThickness = 4;
                line.Stroke = System.Windows.Media.Brushes.Green;


                //left arrow
                Line line2 = new Line();
                line2.Visibility = System.Windows.Visibility.Visible;
                line2.StrokeThickness = 2;
                line2.Stroke = System.Windows.Media.Brushes.Green;

                //right arrow
                Line line3 = new Line();
                line3.Visibility = System.Windows.Visibility.Visible;
                line3.StrokeThickness = 2;
                line3.Stroke = System.Windows.Media.Brushes.Green;


                //x1 = x1 + 20;
                //x2 = x2 + 20;
                line.X1 = x2;
                line.X2 = x2;

                if (current_bit == "0")
                {
                    line.Y1 = 15;
                    line.Y2 = 65;

                    line2.X1 = x2 - 10;
                    line2.X2 = x2;
                    line2.Y1 = line.Y2 - 10;
                    line2.Y2 = line.Y2;

                    line3.X1 = x2;
                    line3.X2 = x2 + 10;
                    line3.Y1 = line.Y2;
                    line3.Y2 = line.Y2 - 10;
                    //draw horrizontal line 
                    // two cases if bit is 0-0 or 1-0
                    if(last_man_bit=="0")
                    {
                       //MessageBox.Show((line.X1- last_man_linex_drawn.X1).ToString()+"\n"+last_man_linex_drawn.X1.ToString()+"\n"+line.X1.ToString());

                        Line line4 = new Line();
                        line4.Visibility = System.Windows.Visibility.Visible;
                        line4.StrokeThickness = 4;
                        line4.Stroke = System.Windows.Media.Brushes.Green;

                        Line line5 = new Line();
                        line5.Visibility = System.Windows.Visibility.Visible;
                        line5.StrokeThickness = 4;
                        line5.Stroke = System.Windows.Media.Brushes.Green;

                        Line line6 = new Line();
                        line6.Visibility = System.Windows.Visibility.Visible;
                        line6.StrokeThickness = 4;
                        line6.Stroke = System.Windows.Media.Brushes.Green;

                        line4.X1 = last_man_linex_drawn.X1;
                        line4.X2 = last_man_linex_drawn.X1 + 25;
                        line4.Y1 = last_man_linex_drawn.Y2;
                        line4.Y2 = last_man_linex_drawn.Y2;
                        line5.X1 = line4.X2;
                        line5.X2 = line5.X1;
                        line5.Y1 = line4.Y1;
                        line5.Y2 = last_man_linex_drawn.Y1;

                        line6.X1 = line5.X1;
                        line6.X2 = line5.X1 + 25;
                        line6.Y1 = line5.Y2;
                        line6.Y2 = line5.Y2;
                        canvas_man.Children.Add(line4);
                        canvas_man.Children.Add(line5);
                        canvas_man.Children.Add(line6);

                        // do color black of previous line
                        foreach(Line l in man_last_line)
                        {
                            l.Stroke = System.Windows.Media.Brushes.Black;
                        }
                        man_last_line.Clear();
                        man_last_line.Add(line4);
                        man_last_line.Add(line5);
                        man_last_line.Add(line6);


                    }
                    else if (last_man_bit=="1")
                    {
                        // draw 1 horrizontal line
                        Line line4 = new Line();
                        line4.Visibility = System.Windows.Visibility.Visible;
                        line4.StrokeThickness = 4;
                        line4.Stroke = System.Windows.Media.Brushes.Green;
                        line4.X1 = last_man_linex_drawn.X1;
                        line4.X2 = line4.X1+50;
                        line4.Y1 = last_man_linex_drawn.Y2;
                        line4.Y2 = line4.Y1;
                        canvas_man.Children.Add(line4);

                        // do color black of previous line
                        foreach (Line l in man_last_line)
                        {
                            l.Stroke = System.Windows.Media.Brushes.Black;
                        }
                        man_last_line.Clear();
                        man_last_line.Add(line4);
                       



                    }

                }

                else
                {
                    // if current bit is 1
                    line.Y1 = 65;
                    line.Y2 = 15;
                    line2.X1 = x2;
                    line2.X2 = x2 - 10;
                    line2.Y1 = line.Y2;
                    line2.Y2 = line.Y2 + 10;

                    line3.X1 = x2;
                    line3.X2 = x2 + 10;
                    line3.Y1 = line.Y2;
                    line3.Y2 = line.Y2 + 10;


                    //draw horrizontal line 
                    // two cases if bit is 0-1 or 1-1
                    if (last_man_bit == "0")
                    {
                       // MessageBox.Show((line.X1 - last_man_linex_drawn.X1).ToString() + "\n" + last_man_linex_drawn.X1.ToString() + "\n" + line.X1.ToString());

                        // draw 1 horrizontal line
                        Line line4 = new Line();
                        line4.Visibility = System.Windows.Visibility.Visible;
                        line4.StrokeThickness = 4;
                        line4.Stroke = System.Windows.Media.Brushes.Green;
                        line4.X1 = last_man_linex_drawn.X1;
                        line4.X2 = line4.X1 + 50;
                        line4.Y1 = last_man_linex_drawn.Y2;
                        line4.Y2 = line4.Y1;
                        canvas_man.Children.Add(line4);

                        // do color black of previous line
                        foreach (Line l in man_last_line)
                        {
                            l.Stroke = System.Windows.Media.Brushes.Black;
                        }
                        man_last_line.Clear();
                        man_last_line.Add(line4);



                    }
                    else if (last_man_bit == "1")
                    {
                        Line line4 = new Line();
                        line4.Visibility = System.Windows.Visibility.Visible;
                        line4.StrokeThickness = 4;
                        line4.Stroke = System.Windows.Media.Brushes.Green;

                        Line line5 = new Line();
                        line5.Visibility = System.Windows.Visibility.Visible;
                        line5.StrokeThickness = 4;
                        line5.Stroke = System.Windows.Media.Brushes.Green;

                        Line line6 = new Line();
                        line6.Visibility = System.Windows.Visibility.Visible;
                        line6.StrokeThickness = 4;
                        line6.Stroke = System.Windows.Media.Brushes.Green;

                        line4.X1 = last_man_linex_drawn.X1;
                        line4.X2 = last_man_linex_drawn.X1 + 25;
                        line4.Y1 = last_man_linex_drawn.Y2;
                        line4.Y2 = last_man_linex_drawn.Y2;
                        line5.X1 = line4.X2;
                        line5.X2 = line5.X1;
                        line5.Y1 = line4.Y1;
                        line5.Y2 = last_man_linex_drawn.Y1;

                        line6.X1 = line5.X1;
                        line6.X2 = line5.X1 + 25;
                        line6.Y1 = line5.Y2;
                        line6.Y2 = line5.Y2;
                        canvas_man.Children.Add(line4);
                        canvas_man.Children.Add(line5);
                        canvas_man.Children.Add(line6);

                        // do color black of previous line
                        foreach (Line l in man_last_line)
                        {
                            l.Stroke = System.Windows.Media.Brushes.Black;
                        }
                        man_last_line.Clear();
                        man_last_line.Add(line4);
                        man_last_line.Add(line5);
                        man_last_line.Add(line6);



                    }


                }



                last_man_y1 = line.Y1;
                last_man_y2 = line.Y2;
                last_man_x1 = line.X2;
                last_man_x2 = line.X2;

                canvas_man.Children.Add(line);
                canvas_man.Children.Add(line2);
                canvas_man.Children.Add(line3);

                man_last_line.Add(line);
                man_last_line.Add(line2);
                man_last_line.Add(line3);
                last_man_linex_drawn = line;
                last_man_bit = current_bit;

                Drawing_man_label(line);

            }
        }
        private void msg_box_KeyUp(object sender, KeyEventArgs e)
        {
            

                char[] temp = msg_box.Text.ToCharArray();
            if (temp.Length <= 12 && temp.Length>0)
            {
                if ((temp[temp.Length - 1].ToString()) == "1" || (temp[temp.Length - 1].ToString()) == "0")
                {




                }
                else
                {
                    MessageBox.Show("only 1 and 0 are allowed");
                }

            }


            else
                MessageBox.Show("maximum 12 bit are allowed");
            }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if(msg_box.Text.Length==0)
            {
                MessageBox.Show("provide some message bit in the form of 0,1");
                return;
            }
            msg_box.IsEnabled = false;
            char[] temp = msg_box.Text.ToCharArray();
            if (item_count <= msg_box.Text.Length - 1)
            {
                if ((temp[item_count].ToString()) == "1" || (temp[item_count].ToString()) == "0")
                {
                    msg_bit.Add(temp[item_count].ToString());
                    current_bit = msg_bit[msg_bit.Count - 1];
                    if (msg_bit.Count > 1)
                        last_bit = msg_bit[msg_bit.Count - 2];
                    //  MessageBox.Show(current_bit+" "+last_bit);
                    if (!nrz_l_started)
                        draw_nrzl(last_x1 + 30, last_x2 + 30);
                    else
                        draw_nrzl(last_x2, last_x2 + 50);

                    if (!nrz_I_started)
                        draw_nrzI(nrzI_last_x1 + 30, nrzI_last_x2 + 30);
                    else
                        draw_nrzI(nrzI_last_x2, nrzI_last_x2 + 50);

                    if (!bipolar_started)
                        draw_bipolar(last_bipolar_x1 + 30, last_bipolar_x2 + 30);
                    else
                        draw_bipolar(last_bipolar_x2,last_bipolar_x2 + 50);

                    if (!psuedo_t_started)
                        draw_psuedo_t(last_psuedo_t_x1 + 30, last_psuedo_t_x2 + 30);
                    else
                        draw_psuedo_t(last_psuedo_t_x2, last_psuedo_t_x2 + 50);

                    if (!man_started)
                        draw_man(last_man_x1 + 50, last_man_x2 + 50);
                    else
                        draw_man(last_man_x2, last_man_x2 + 50);


                    item_count++;



                }
                else
                {
                     MessageBox.Show("only 1 and 0 are allowed");
                }

            }

            else
            {
                MessageBox.Show("no more bit left");
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }

     
    }

