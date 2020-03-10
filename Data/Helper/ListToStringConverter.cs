using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace LMSData
{
    /// <summary>
    /// Baseclass that allows persisting of scalar values as a collection (which is not supported by EF 4.3)
    /// </summary>
    /// <typeparam name="T">Type of the single collection entry that should be persisted.</typeparam>
    
    public static class ListToStringConverter
    {

        // use a character that will not occur in the collection.
        // this can be overriden using the given abstract methods (e.g. for list of strings).
        const string DefaultValueSeperator = "|";

        readonly static string[] DefaultValueSeperators = new string[] { DefaultValueSeperator };

        /// <summary>
        /// The internal data container for the list data.
        /// </summary>
        private static List<string> Data { get; set; }

        /// <summary>
        /// Deriving classes can override the string that is used to seperate single values
        /// </summary>        
        public static string ValueSeperator
        {
            get
            {
                return DefaultValueSeperator;
            }
        }

        /// <summary>
        /// Deriving classes can override the string that is used to seperate single values
        /// </summary>        
        public static string[] ValueSeperators
        {
            get
            {
                return DefaultValueSeperators;
            }
        }

        public static string SerializedValue(IEnumerable<string> _data)
        {
            
            return string.Join(ValueSeperator.ToString(),
                _data.Select(x => x.ToString())
                .ToArray());
        }


        public static IEnumerable<string> DeserializedValue(string value)
        {
            return new List<string>(value.Split(ValueSeperators, StringSplitOptions.None)
                .Select(x => x.ToString()));
        }

        /*
        public static string SerializedFhirUri(IEnumerable<FhirUri> _data)
        {

            return string.Join(ValueSeperator.ToString(),
                _data.Select(x => x.Value)
                .ToArray());
        }


        public static List<FhirUri> DeserializedFhirUri(string value)
        {
            return new List<FhirUri>(value.Split(ValueSeperators, StringSplitOptions.None)
                .Select(x => new FhirUri(x.ToString())));
        }


        public static string SerializedFhirString(IEnumerable<FhirString> _data)
        {

            return string.Join(ValueSeperator.ToString(),
                _data.Select(x => x.Value)
                .ToArray());
        }


        public static List<FhirString> DeserializedFhirString(string value)
        {
            return new List<FhirString>(value.Split(ValueSeperators, StringSplitOptions.None)
                .Select(x => new FhirString(x.ToString())));
        }
        */
    }
}
