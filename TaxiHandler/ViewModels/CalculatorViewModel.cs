using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using TaxiHandler.Models;
using TaxiHandler.Services;

namespace TaxiHandler.ViewModels
{
    public class CalculatorViewModel : ItemsViewModel
    {
        private string numberOfPeople = "0";
        private string initAmount = "12.5";
        private string givenAmount = "0";
        private string answer = "0";
        private int forcusIndex = 0;
        private int forcusIndexY = 1;
        private double num;
        private double nump;
        private ObservableCollection<Counts> counted;
        CountedData directData = new CountedData();
       

        public ObservableCollection<Counts> Counted
        {
            get => counted;
            set
            {
                SetProperty(ref counted, value);
                OnPropertyChanged(nameof(Counted));
            }
        }

        public int ForcusIndexY
        {
            get => forcusIndexY;
            set
            {
                SetProperty(ref forcusIndexY, value);
                OnPropertyChanged(nameof(ForcusIndexY));
            }
        }

        public string NumberOfPeople
        {
            get => numberOfPeople;
            set
            {
                SetProperty(ref numberOfPeople, value);
                OnPropertyChanged(nameof(NumberOfPeople));
            }

        }
        public string InitAmount
        {
            get => initAmount;
            set
            {
                SetProperty(ref initAmount, value);
                OnPropertyChanged(nameof(InitAmount));
            }
        }
        public string GivenAmount
        {
            get => givenAmount;
            set
            {
                SetProperty(ref givenAmount, value);
                OnPropertyChanged(nameof(GivenAmount));
            }
        }
        public string Answer
        {
            get => answer;
            set
            {
                SetProperty(ref answer, value);
                OnPropertyChanged(nameof(Answer));
            }
        }

        public int ForcusIndex
        {
            get => forcusIndex;
            set
            {
                SetProperty(ref forcusIndex, value);
                OnPropertyChanged(nameof(ForcusIndex));
            }
        }

        








        public Command<string> Indexs { get; }
        public Command<string> Number { get; }
  
        public Command Del { get; }
        public Command Next { get; }
      



        public CalculatorViewModel()
        {
        
            Indexs = new Command<string>(OnIndexs);
            Number = new Command<string>(OnNumber);
            Next = new Command(OnNext);
            Del = new Command(OnDel);
            getItems();
            
        }


        void OnDel()
        {

            if (ForcusIndexY == 0)
            {

                if (ForcusIndex == 0)
                {

                    NumberOfPeople = RemoveLast(NumberOfPeople);

                   


                }
                else
                {
                    GivenAmount = RemoveLast(GivenAmount);
                   
                    GiveAnswer();
                }


            }
            else
            {
                InitAmount = RemoveLast(InitAmount);
            }

        }

        private  void getItems()
        {
            ObservableCollection<Counts> lists = new ObservableCollection<Counts>();
            var list = directData.GetItems();
            foreach (var item in list)
            {
                lists.Add(item);
            }
            Counted = lists;
        }

        private  void ReLoadItems()
        {
            ObservableCollection<Counts> counts = new ObservableCollection<Counts>();
            var items = directData.GetItems();;
            foreach (var item in items)
            {
                counts.Add(item);
            }

            Counted.Clear();
            Counted = counts;


        }
        private void Additem(Counts item)
        {
            directData.Additem(item);
            ReLoadItems();
        }
        private string RemoveLast(string item)
        {
                string outp;
            if(item.Length >= 1)
            {
            int lenght = item.Length;
           outp = item.Remove(lenght - 1);
                return outp;

            }
            else
            {
                outp = "0";
                return outp;
            }

        }




        void OnIndexs(string index)
        {
            if(index != "oney")
            {

                if (index == "one")
                {
                    ForcusIndex = 0;
                    ForcusIndexY = 0;
                }
                else 
                {
                    ForcusIndex = 1;
                    ForcusIndexY = 0;
                }
            }
            else
            {
                ForcusIndex = 0;
                ForcusIndexY = 1;


            }

        }
      
      
       async void OnNext()
        {
            if(ForcusIndexY == 1)
            {
                ForcusIndexY = 0;
            }
            else
            {

                if (ForcusIndex == 0)
                {
                    ForcusIndex = 1;
                }
                else
                {

                    try
                    {

                    //Add to list
                    var item = new Counts() {
                        ID = Guid.NewGuid().ToString(),
                        Change = Answer,
                        InitialAmount = GivenAmount,
                        NumberOfPeople = NumberOfPeople

                    };
                         Additem(item);
                        Answer = "0";
                        GivenAmount = "0";
                        NumberOfPeople = "0";
                        ForcusIndex = 0;

                        
                    }
                    catch(Exception ex)
                    {
                        await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                    }




                }

            }



        }
        void OnNumber(string act)
        {
            inputH(act);
        }




        double changeInput(string input)
        {
            return double.Parse(input);
        }


        string AddChange(string current,string unit)
        {
             double.Parse(current);
            if(double.Parse(current) == 0)
            {
                return unit;
            }
            else
            {

            string change = current + unit;
 
            return change;
            }

        }



        void GiveAnswer()
        {
            double ans =   changeInput(GivenAmount) - (changeInput(InitAmount) * changeInput(NumberOfPeople));
            
                Answer = ans.ToString();

            
        }

         


        void inputH(string act)
        {
            if(act == "one")
            {
                if(ForcusIndexY == 0)
                {

                    if(ForcusIndex == 0)
                    {
                  
                       NumberOfPeople = AddChange(NumberOfPeople, "1");
                        nump = changeInput(NumberOfPeople);
                    

                    }
                    else 
                    {
                        GivenAmount = AddChange(GivenAmount, "1");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }


                }
                else
                {
                    InitAmount = AddChange(InitAmount, "1");
                }





            }
            else if (act == "two")
            {

                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "2");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "2");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }

                }
                else
                {
                    InitAmount = AddChange(InitAmount, "2");
                }

            }
            else if (act == "three")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "3");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "3");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, "3");
                }


            }
            else if (act == "four")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "4");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "4");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, "4");
                }

            }
            else if (act == "five")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "5");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "5");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, "5");
                }

            }
            else if (act == "six")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "6");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "6");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, "6");
                }

            }
            else if (act == "seven")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "7");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "7");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }

                }
                else
                {
                    InitAmount = AddChange(InitAmount, "7");
                }

            }
            else if (act == "eight")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "8");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "8");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, "8");
                }

            }
            else if (act == "nine")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "9");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "9");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, "7");
                }

            }
            else if (act == "zero")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, "0");
                        nump = changeInput(NumberOfPeople);

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, "0");
                        num = changeInput(GivenAmount);
                        GiveAnswer();
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, "0");
                }

            }
            else if (act == "dot")
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = AddChange(NumberOfPeople, ".");
                   

                    }
                    else
                    {
                        GivenAmount = AddChange(GivenAmount, ".");
                   
                    }
                }
                else
                {
                    InitAmount = AddChange(InitAmount, ".");
                }

            }
            else
            {
                if(ForcusIndexY == 0)
                {

                    if (ForcusIndex == 0)
                    {

                        NumberOfPeople = "0";
                        nump = 0;


                    }
                    else
                    {
                        GivenAmount = "0";
                        num = 0;

                    }
                }
                else
                {
                    InitAmount = "0";
                }
            }

        }




    }
}
