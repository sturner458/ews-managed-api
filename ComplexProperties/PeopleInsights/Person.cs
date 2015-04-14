/*
 * Exchange Web Services Managed API
 *
 * Copyright (c) Microsoft Corporation
 * All rights reserved.
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */

namespace Microsoft.Exchange.WebServices.Data
{
    /// <summary>
    /// Represents the Person.
    /// </summary>
    public class Person : ComplexProperty
    {
        /// <summary>
        /// Initializes a local instance of <see cref="Person"/>
        /// </summary>
        public Person()
            : base()
        {
        }

        /// <summary>
        /// Gets the EmailAddress.
        /// </summary>
        public string EmailAddress
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the collection of insights.
        /// </summary>
        public PersonInsightCollection Insights
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Tries to read element from XML.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>True if element was read.</returns>
        internal override bool TryReadElementFromXml(EwsServiceXmlReader reader)
        {
            switch (reader.LocalName)
            {
                case XmlElementNames.EmailAddress:
                    this.EmailAddress = reader.ReadElementValue();
                    break;
                case XmlElementNames.DisplayName:
                    this.DisplayName = reader.ReadElementValue();
                    break;
                case XmlElementNames.Insights:
                    this.Insights = new PersonInsightCollection();
                    this.Insights.LoadFromXml(reader, XmlNamespace.Types, XmlElementNames.Insights);
                    break;
                default:
                    return base.TryReadElementFromXml(reader);
            }

            return true;
        }
    }
}