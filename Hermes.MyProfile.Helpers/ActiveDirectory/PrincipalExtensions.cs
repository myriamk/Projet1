using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hermes.MyProfile.Helpers.ActiveDirectory
{
    public static class PrincipalExtensions
    {



        public static bool IsAttributeDefined(this Principal prin, string attribute)
        {
            // since some attributes may not exist in all schemas check to see if it exists first
            DirectoryEntry uo = prin.GetUnderlyingObject() as DirectoryEntry;

            // check for property, if it's not found return an empty array
            return uo.Properties.Contains(attribute);
        }


        public static object[] ExtensionGetAttributeObject(this Principal prin, string attribute)
        {
            if (IsAttributeDefined(prin, attribute))
            {
                // if property exists then return the data
                DirectoryEntry uo = prin.GetUnderlyingObject() as DirectoryEntry;
                object[] val = uo.Properties[attribute].Cast<object>().ToArray();

                return val;
            }
            else
            {

                return new object[] {
                        -1};
            }

        }


        public static object ExtensionGetSingleValue(this Principal prin, string attribute)
        {
            // get the object
            object[] attributeValues = ExtensionGetAttributeObject(prin, attribute);

            if ((attributeValues.Length > 0))
            {
                return attributeValues[0];
            }
            else
            {
                return null;
            }

        }



        public static string ExtensionGetSingleString(this Principal prin, string attribute)
        {
            object o = ExtensionGetSingleValue(prin, attribute);
            return (o != null) ? o.ToString() : String.Empty;


        }


        public static string[] ExtensionGetMultipleString(this Principal prin, string attribute)
        {
            object[] attributeValues = ExtensionGetAttributeObject(prin, attribute);
            // create a string array of the same length as the object array
            string[] array = new string[attributeValues.Length];
            for (int i = 0; i <= attributeValues.Length - 1; i++)
            {
                array[i] = attributeValues[i].ToString();
            }

            // return the string array
            return array;
        }



        public static byte[] ExtensionGetBytes(this Principal prin, string attribute)
        {
            object o = ExtensionGetSingleValue(prin, attribute);

            // return the data
            return (o != null) ? (byte[])o : null;
        }

        // '' <summary>
        // '' Gets the image contained in an Octet String type attribute
        // '' </summary>

        public static Image ExtensionGetImage(this Principal prin, string attribute)
        {
            // get bytes for attribute
            byte[] bytearray = ExtensionGetBytes(prin, attribute);
            Image ret;

            // read the bytes into a memory stream
            using (MemoryStream ms = new MemoryStream(bytearray))
            {

                // convert the memory stream to a bitmap and return it
                ret = new Bitmap(ms);

            }
            return ret;
        }

        
        public static Image[] ExtensionGetImages(this Principal prin, string attribute)
        {
            object[] vals = ExtensionGetAttributeObject(prin, attribute);
            // array to hold images to be returned
            List<Image> al = new List<Image>();
            foreach (object o in vals)
            {
                byte[] bytearray = ExtensionGetBytes(prin, attribute);
                // read the bytes into a memory stream
                using (MemoryStream ms = new MemoryStream(bytearray))
                {
                    al.Add(new Bitmap(ms));
                }

            }

            // return the list of images as an array.
            return al.ToArray();
        }

        private static void ExtensionSetDE(this DirectoryEntry de, string attribute, object value)
        {

            if (value != null)
            {

                de.Properties[attribute].Add(value);
            }

        }


        public static void ExtensionSetValue(this Principal prin, string attribute, object value)
        {
            DirectoryEntry uo = prin.GetUnderlyingObject() as DirectoryEntry;
            uo.Properties[attribute].Clear();
            ExtensionSetDE(uo, attribute, value);
        }


        public static void ExtensionSetStringValue(Principal prin, string attribute, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = null;
            }

            ExtensionSetValue(prin, attribute, value);
        }


        public static void ExtensionSetMultipleValueDirect(this Principal prin, string attribute, object[] values)
        {
            // Normal ExtensionSet does not support saving array type values (octet string)
            //  so we set it directly on the underlying object
            DirectoryEntry uo = prin.GetUnderlyingObject() as DirectoryEntry;
            uo.Properties[attribute].Clear();
            if (values != null)
            {
                foreach (object v in values)
                {
                    ExtensionSetDE(uo, attribute, v);
                }

            }

        }


        public static void ExtensionSetImage(this Principal prin, string attribute, Image img)
        {

            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // save data to a byte array
                bytes = ms.ToArray();
            }

            ExtensionSetValue(prin, attribute, bytes);
        }



        public static void ExtensionSetImages(this Principal prin, string attribute, Image[] img)
        {
            ArrayList al = new ArrayList();
            // convert each image into a byte array
            foreach (Image i in img)
            {
                byte[] bytes;
                using (MemoryStream ms = new MemoryStream())
                {

                    i.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    // save data to a byte array
                    bytes = ms.ToArray();
                }

                al.Add(bytes);
            }

            // set image array as value on attribute
            ExtensionSetMultipleValueDirect(prin, attribute, al.ToArray());






        }
    }
}