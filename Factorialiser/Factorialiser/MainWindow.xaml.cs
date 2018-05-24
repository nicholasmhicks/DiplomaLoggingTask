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
using Factorialiser.Classes;
using NLog;

namespace Factorialiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            _logger.Trace("Main Window Loaded");
        }

        public void MainWindow_Closed(object sender, EventArgs e)
        {
            _logger.Trace("Main Window Closed");
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // check if textboxInput.Text is empty (or only contains white space), 
                // if this is the case then throw a NullValueException

                //declare a variable here called input or datatype int
                if (String.IsNullOrWhiteSpace(textBoxInput.Text)) throw new NullValueException();

                int input = 0;
                try
                {
                    // try and parse the text input into textboxInput into an integer and assign it to input
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input successfully parsed"
                    input = Int32.Parse(textBoxInput.Text);
                    _logger.Debug("input successfully parsed");
                }
                catch
                {
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input parse failed"
                    // throw a NotIntegerException 
                    _logger.Debug("input parse failed");
                }


                // pass the input to the Calculator.Factorial method and store the retuen value in a variable
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: Calculate.Factorial suceeded"
                var value = Calculator.Factorial(input);
                _logger.Debug("Calculate.Factorial succeeded");
                // change the text of labelOutput to reflect
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: labelOutput successfully updated"
                labelOutput.Content = value;
                _logger.Debug("labelOutput successfully updated");

            }
            catch (NullValueException)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Nothing Entered - Please enter an integer")
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"

            }

            // ###########
            // add additional catches here, one for each of your custom exception types, in each one
            // clear the labelOutput text and the textboxInput.Text
            // display an approprate message box message and log the event as an Error level
            // using the same format as used in the NullValueException catch
            // ##########

            catch (Exception ex)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Unknown Error")
                // log the event as an Fatal Level log 
                // with the message ("MainForm.buttonCalculate_Click: Unknown Error : " + ex.message)
            }


        }
    }
}
