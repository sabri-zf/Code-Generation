using System;

namespace Code_Generation
{
    public class Colums
    {

        private string _name;
        private string _dataType;
        private bool _isNull;


        public string Name
        { 
            get { return _name; } 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("please Can not leave this out put empty");
                }

                _name = value; 
            }
        }

        public string DataType
        {
            get { return _dataType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("please Can not leave this out put empty");
                }

                _dataType = value;
            }
        }

        public bool IsNull
        {
            get { return _isNull; }
            set { _isNull = value; }
        }


        public Colums(string name, string dataType, bool isNull)
        {
            this.Name = name;
            this.DataType = dataType;
            this.IsNull = isNull;
        }


        public override string ToString()
        {
            return $"{{Data Type : {DataType}, Name : {Name}, IsNull : {IsNull}}}";
        }


    }
}
