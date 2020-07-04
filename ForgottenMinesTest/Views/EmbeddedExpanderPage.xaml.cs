using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using ForgottenMinesTest.Views;
using System.Collections.Generic;
using System.Linq;
using TouchTracking;
using Xamarin.Forms.Xaml;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using System.Diagnostics;
using Windows.UI.WebUI;
using Xamarin.Essentials;
using Windows.UI.Input;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]


namespace ForgottenMinesTest.Views
{
    public partial class EmbeddedExpanderPage : ContentPage
    {

        class DragInfo
        {
            public DragInfo(long id, Point pressPoint)
            {
                Id = id;
                PressPoint = pressPoint;
            }

            public long Id { private set; get; }

            public Point PressPoint { private set; get; }
        }

        Dictionary<Grid, DragInfo> dragDictionary = new Dictionary<Grid, DragInfo>();

        int FisrtExpandertapCount = 0;

        int SecondExpandertapCount = 0;




        public EmbeddedExpanderPage()
        {

            InitializeComponent();
            addDragEffectToNode1Currency();
            Expander3.IsExpanded = true;
            FirstExpander.IsExpanded = true;
            SecondExpander.IsExpanded=true;
            Expander4.IsExpanded = true;

        }




        public void addDragEffectToNode1Currency()
        {




            string currencyyparameter = "CurrencyInput";
            Grid NewView = new Grid
            {
                HeightRequest = 30,
                
                Children = {
                    new BoxView {BackgroundColor= Color.Black },
                    new Grid { BackgroundColor= Color.White ,Margin= 2 ,   Children={
                            new Label{
                             Margin=0,
                            HeightRequest=300,
                            WidthRequest=269,
                            BackgroundColor=ColorConverters.FromHex("#00B0F0"),
                            Text= currencyyparameter ,
                            HorizontalOptions=LayoutOptions.Center,
                            HorizontalTextAlignment =Xamarin.Forms.TextAlignment.Center }
                        }


                    }


                }



            };

         

            TouchEffect touchEffect = new TouchEffect();

            touchEffect.TouchAction += OnTouchEffectActionToNode1Currency;

            NewView.Effects.Add(touchEffect);

           

            MainGrid14.RaiseChild(MainGrid15);


            absoluteLayout1.Children.Add(NewView);
            
            


        }


        void OnTouchEffectActionToNode1Currency(object sender, TouchActionEventArgs args)
        {

            
            


            Grid View = sender as Grid;



            switch (args.Type)
            {
                case TouchActionType.Pressed:


                    // Don't allow a second touch on an already touched BoxView
                    if (!dragDictionary.ContainsKey(View))
                    {

                       
                        



                        View.Opacity = .5;
                        
                              

                        dragDictionary.Add(View, new DragInfo(args.Id, args.Location));


                        // Set Capture property to true
                        TouchEffect touchEffect = (TouchEffect)View.Effects.FirstOrDefault(e => e is TouchEffect);
                        touchEffect.Capture = true;
                        addDragEffectToNode1Currency();
                    }
                    break;

                case TouchActionType.Moved:

                    if (dragDictionary.ContainsKey(View) && dragDictionary[View].Id == args.Id)
                    {

                        Rectangle rect = AbsoluteLayout.GetLayoutBounds(View);

                        Point initialLocation = dragDictionary[View].PressPoint;
                        rect.X += args.Location.X - initialLocation.X;
                        rect.Y += args.Location.Y - initialLocation.Y;
                        AbsoluteLayout.SetLayoutBounds(View, rect);


                    }
                    break;

                case TouchActionType.Released:




                    if (dragDictionary.ContainsKey(View) && dragDictionary[View].Id == args.Id)
                    {

                        Rectangle rect = AbsoluteLayout.GetLayoutBounds(View);

                        Point initialLocation = dragDictionary[View].PressPoint;
                        dragDictionary.Remove(View);


                        Rectangle currency = AbsoluteLayout.GetLayoutBounds(FisrtNodeCurrencyInput);

                        Debug.WriteLine(FisrtNodeCurrencyInput.Rotation);

                        Debug.WriteLine(rect.X);

                        View.IsVisible = false;
                        












                    }
                    break;


            }
        }











       //controls buttons  
        void OnTapFirstExpander(object sender, EventArgs args)
        {

            FisrtExpandertapCount++;



            if (FisrtExpandertapCount % 2 == 0)
            {

                if (SecondExpander.IsExpanded == false)
                {
                    SecondExpander.IsExpanded = true;
                    Expander4.IsExpanded = true;

                }

                else if (SecondExpander.IsExpanded == true && Expander3.IsExpanded == true)
                {
                    SecondExpander.IsExpanded = false;
                    Expander3.IsExpanded = false;
                    Expander4.IsExpanded = false;

                }
                else if (SecondExpander.IsExpanded == true)
                {
                    SecondExpander.IsExpanded = false;
                    Expander4.IsExpanded = false;
                }

            }





        }

        void OnTapSecondExpander(object sender, EventArgs args)
        {
            SecondExpandertapCount++;


            if (SecondExpandertapCount % 2 == 0)
            {
                if (Expander3.IsExpanded == false)
                {
                    Expander3.IsExpanded = true;

                }
                else
                {
                    Expander3.IsExpanded = false;
                }

            }





        }

        void OnTapExpander3(object sender, EventArgs args)
        {
            SecondExpandertapCount++;


            if (SecondExpandertapCount % 2 == 0)
            {
                if (Expander3.IsExpanded == false)
                {
                    Expander3.IsExpanded = true;

                }
                else
                {
                    Expander3.IsExpanded = false;
                }

            }





        }

        void OnTapSecondExpander4(object sender, EventArgs args)
        {
            SecondExpandertapCount++;


            if (SecondExpandertapCount % 2 == 0)
            {
                if (Expander3.IsExpanded == false)
                {
                    Expander3.IsExpanded = true;

                }
                else
                {
                    Expander3.IsExpanded = false;
                }

            }





        }

        void OnButton1Clicked(object sender, EventArgs args)
        {
            int tapCount = 0;



            if (tapCount % 2 == 0)
            {
                if (SecondExpander.IsExpanded == false && Expander4.IsExpanded == false)
                {
                    //nothing to do 

                }
                else
                {
                    Expander4.IsExpanded = false;
                    SecondExpander.IsExpanded = false;
                    Expander3.IsExpanded = false;
                }

            }




        }

        void OnButton2Clicked(object sender, EventArgs args)
        {
            int tapCount = 0;


            if (tapCount % 2 == 0)
            {
                if (SecondExpander.IsExpanded == false)
                {
                    SecondExpander.IsExpanded = true;


                }
                else
                {
                    SecondExpander.IsExpanded = false;
                    Expander3.IsExpanded = false;

                }

            }




        }


        void OnButton3Clicked(object sender, EventArgs args)
        {
            int tapCount = 0;


            if (tapCount % 2 == 0)
            {
                if (Expander3.IsExpanded == false)
                {
                    Expander3.IsExpanded = true;

                }
                else
                {
                    Expander3.IsExpanded = false;
                }

            }




        }

        void OnButton4Clicked(object sender, EventArgs args)
        {
            int tapCount = 0;


            if (tapCount % 2 == 0)
            {
                if (Expander4.IsExpanded == false)
                {
                    Expander4.IsExpanded = true;

                }
                else
                {
                    Expander4.IsExpanded = false;
                }

            }




        }







        void OnAlertYesNoClicked(object sender, EventArgs args)
        {
            DisplayAlert("This","Market","Test PopUp");
            Debug.WriteLine("Tap");
            

        }










    }
}
