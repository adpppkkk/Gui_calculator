using System;

using AppKit;
using Foundation;

namespace Gui_calculator
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        string input = "";
        string result = "";
        bool operation = true;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.

            
            TextField.Alignment = NSTextAlignment.Right;
            UpdateText();
        }

        // function that update the textfield
        public void UpdateText()
        {
            TextField.StringValue = input + "\n---------------------\n";
        }

        public void UpdateTextWithRes()
        {
            TextField.StringValue = input + "\n---------------------\n" + result;
        }


        // all the clicking button functions
        partial void Button0Onclick(Foundation.NSObject sender)
        {
            if(operation)
            {
                input += "0";
                UpdateText();
            }
            
        }

        partial void Button1Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "1";
                UpdateText();
            }                
        }

        partial void Button2Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "2";
                UpdateText();
            }
        }

        partial void Button3Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "3";
                UpdateText();
            }
        }
        partial void Button4Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "4";
                UpdateText();
            }
        }
        partial void Button5Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "5";
                UpdateText();
            }
        }
        partial void Button6Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "6";
                UpdateText();
            }
        }
        partial void Button7Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "7";
                UpdateText();
            }
        }
        partial void Button8Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "8";
                UpdateText();
            }
        }
        partial void Button9Onclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "9";
                UpdateText();
            }
        }

        partial void ButtonDecimalOnclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += ".";
                UpdateText();
            }
        }

        partial void ButtonPlusOnclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "+";
                UpdateText();
            }
        }

        partial void ButtonMinusOnclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "-";
                UpdateText();
            }
        }

        partial void ButtonpmOnclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "-";
                UpdateText();
            }
        }
        partial void ButtonMultiplyOnclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "*";
                UpdateText();
            }
        }
        partial void ButtonDivideOnclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "/";
                UpdateText();
            }
        }
        partial void ButtonModOnclick(Foundation.NSObject sender)
        {
            if (operation)
            {
                input += "%";
                UpdateText();
            }
        }

       



        partial void ButtonEqualOnclick(Foundation.NSObject sender)
        {
            int Find(string x, char f)
            {
                int res;
                //bool isNegative = false;
                for (int i = 0; i < x.Length; i++)
                {
                    //if - at index 0, ignor it
                    if (f == '-' && x[0] == '-' && i == 0)
                    {
                        i++;
                        //Console.WriteLine("negative num");
                        //isNegative = true;
                    }
                    else if (x[i] == f)
                    {
                        //Console.WriteLine("- at {0}",i);
                        res = i;
                        return res;
                    }
                }
                return -1;
            }

            string LocalMath(string x, int index)
            {
                // index hold the operater is going to use
                int indexl = index - 1;
                int indexr = index + 1;
                //bool isNegativeL = false;
                //bool isNegativeR = false;
                string res;
                // finding the numbers need to be operate
                if (indexl < 0)
                    return x;

                else
                {
                    if (x[indexr] == '-') // if right hand side has a negative num
                    {
                        //isNegativeR = true;
                        indexr++;
                    }
                    //finding the bound of the number on left and right
                    while (x[indexl] != '*' && x[indexl] != '/' && x[indexl] != '+' && x[indexl] != '-' && x[indexl] != '%' && indexl > 0)
                    {
                        indexl--;
                    }
                    while (x[indexr] != '*' && x[indexr] != '/' && x[indexr] != '+' && x[indexr] != '-' && x[indexr] != '%' && indexr < x.Length - 1)
                    {
                        indexr++;
                    }
                    // the case that we have + at beginning 
                    if (indexl - 1 == 0 && x[0] == '+')
                        x = x.Substring(1);
                    else if (indexl - 1 > 0 && (x[indexl - 1] != '*' || x[indexl - 1] != '/' || x[indexl - 1] != '+' || x[indexl - 1] != '-' || x[indexl - 1] != '%'))
                        indexl++;
                    if (indexr + 1 <= x.Length - 1 && (x[indexr + 1] != '*' || x[indexr + 1] != '/' || x[indexr + 1] != '+' || x[indexr + 1] != '-' || x[indexr + 1] != '%'))
                        indexr--;
                    double numl = Convert.ToDouble(x.Substring(indexl, index - indexl));
                    double numr = Convert.ToDouble(x.Substring(index + 1, indexr - index));

                    //operations 
                    if (x[index] == '*')
                    {
                        //Console.WriteLine("* at {0} is {1}", index,x[index]);
                        //Console.WriteLine("{0} times {1}",numl,numr);
                        res = Convert.ToString(numl * numr);
                    }
                    else if (x[index] == '/')
                    {
                        res = Convert.ToString(numl / numr);
                    }
                    else if (x[index] == '%')
                    {
                        res = Convert.ToString(numl % numr);
                    }
                    else if (x[index] == '+')
                    {
                        res = Convert.ToString(numl + numr);
                    }
                    else
                    {
                        res = Convert.ToString(numl - numr);
                    }
                    res = x.Substring(0, indexl) + res + x.Substring(indexr + 1, x.Length - indexr - 1);

                    return res;

                }
            }
            //getting input
            string n = input;
            //order of operations *>/>%>+>-
            int indexnum = Find(n, '*');
            while (indexnum != -1)
            {
                n = LocalMath(n, indexnum);
                Console.WriteLine(n);
                indexnum = Find(n, '*');
            }
            indexnum = Find(n, '/');
            while (indexnum != -1)
            {
                n = LocalMath(n, indexnum);
                Console.WriteLine(n);
                indexnum = Find(n, '/');
            }
            indexnum = Find(n, '%');
            while (indexnum != -1)
            {
                n = LocalMath(n, indexnum);
                Console.WriteLine(n);
                indexnum = Find(n, '%');
            }
            indexnum = Find(n, '+');
            while (indexnum != -1)
            {
                n = LocalMath(n, indexnum);
                Console.WriteLine(n);
                indexnum = Find(n, '+');
            }
            indexnum = Find(n, '-');
            while (indexnum != -1 && indexnum != 0)
            {
                n = LocalMath(n, indexnum);
                Console.WriteLine(n);
                indexnum = Find(n, '-');
            }

            //update the result
            result = n;
            UpdateTextWithRes();
            operation = false;
        }


        partial void ButtonAllClearOnclick(Foundation.NSObject sender)
        {
            input = "";
            UpdateText();
            operation = true;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
