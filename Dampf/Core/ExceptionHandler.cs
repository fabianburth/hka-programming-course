using System;
using System.Windows;
using System.Runtime.ExceptionServices;

namespace Dampf.Core
{
    // This is definitely not the best solution performance wise, but passing the ExceptionDispatchInfo allows to throw the exception
    // with the stacktrace here again - hence it allows us to dispatch the exception handling neatly into a seperate class without losing information
    // Passing the exception enables dynamic calling of the right method through overloading
    public class ExceptionHandler
    {
        public static void DispatchException(ExceptionDispatchInfo e)
        {
            if(e.SourceException is IndexOutOfRangeException)
            {
                HandleIndexOutOfRangeException(e);
            } 
            else if (e.SourceException is DivideByZeroException)
            {
                HandleDivideByZeroException(e);
            }
            else if (e.SourceException is NullReferenceException)
            {
                HandleNullReferenceException(e);
            }
            else
            {
                e.Throw();
            }
        }
        public static void HandleIndexOutOfRangeException(ExceptionDispatchInfo e)
        {
            MessageBoxResult result = MessageBox.Show("Du hast versucht auf einen Index in deinem Array zuzugreifen, den es nicht gibt. \n" +
                "Erinnerung: Der Index beginnt immer bei 0\n" +
                "Beispiel: \n string[] myarray = {Apfel,Birne,Orange} \n" +
                "                                   ^     ^      ^ \n" +
                "                   Index:      0      1      2 \n" +
                "Häufig tritt dieser Fehler durch falsche Bedingungen in for-Schleifen auf. \n\n" +
                "Willst du die Ausnahme werfen?", "EXCEPTION", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                e.Throw();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public static void HandleDivideByZeroException(ExceptionDispatchInfo e)
        {
            MessageBoxResult result = MessageBox.Show("Du hast versucht eine Ganzzahl (=Integer) durch 0 zu teilen. Das ist nicht möglich. \n\n" +
                "Willst du die Ausnahme werfen?", "EXCEPTION", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                e.Throw();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public static void HandleNullReferenceException(ExceptionDispatchInfo e)
        {
            MessageBoxResult result = MessageBox.Show("Du hast versucht eine Referenzvariable zu verwenden, die kein Objekt referenziert. \n" +
                "Das kann beispielsweise passiert sein, weil du vergessen hast, ein Array zu verwenden, bevor du dessen Größe beziehungsweise Dimension festgelegt hast.\n" +
                "int[] values = null\n" +
                "values[1] = 2\n\n" +
                "Willst du die Ausnahme werfen?", "EXCEPTION", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                e.Throw();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
