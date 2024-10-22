using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generation
{
    public partial class GeneraterEintity
    {
        public enum AccessSpecifier 
        {
            Public = 0,
            Protected = 1,
            Private = 2,
        }
        public string TableName { get; set; }
        private List<Colums> List { get; set; }
       
        public GeneraterEintity(string TableName ,List<Colums> colums) 
        {
            this.TableName = TableName;
            this.List = colums;
        }



        public StringBuilder GenerateFunctionAddNew(AccessSpecifier Type)
        {
            StringBuilder sb = new StringBuilder();
            sb = (Type == AccessSpecifier.Public) ? sb.Append(Type + " bool ") : sb.Append(Type + " bool _");
            sb.Append($"AddNew{TableName} (");

            foreach (Colums colum in List)
            {
                if (!colum.Name.Contains("ID"))
                {
                    if (colum.IsNull)
                        sb.Append(colum.DataType + "? " + colum.Name + ',');
                    else
                        sb.Append(colum.DataType + ' ' + colum.Name + ',');

                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("){");

            // logic Of Reflection query

            sb.Append('}');
            return sb;
        }

        public StringBuilder GenerateFunctionUpdate(AccessSpecifier Type)
        {
            StringBuilder sb = new StringBuilder();
            sb = (Type == AccessSpecifier.Public) ? sb.Append(Type + " bool ") : sb.Append(Type + " bool _");
            sb.Append($"Update{TableName} (");

            foreach (Colums colum in List)
            {
                //colum.
                if (colum.IsNull)
                    sb.Append(colum.DataType + "? " + colum.Name + ',');
                else
                    sb.Append(colum.DataType + ' ' + colum.Name + ',');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("){");

            // logic Of Reflection query

            sb.Append('}');
            return sb;
        }

        public StringBuilder GenerateFunctionFind(AccessSpecifier Type)
        {
            StringBuilder sb = new StringBuilder();
            sb = (Type == AccessSpecifier.Public) ? sb.Append(Type + $" Cls{TableName} ") : sb.Append(Type + $" Cls{TableName} _");

            foreach (Colums colum in List)
            {
                //colum.
                if (colum.Name.Contains("ID"))
                {
                    if (colum.IsNull)
                    {
                        sb.Append($"Find{TableName}By{colum.Name} (");
                        sb.Append(colum.DataType + "? " + colum.Name);
                    }
                    else
                    {
                        sb.Append($"Find{TableName}By{colum.Name} (");
                        sb.Append(colum.DataType + ' ' + colum.Name);
                    }

                    break;
                }
            }
            //sb.Remove(sb.Length - 1, 1);
            sb.Append("){");

            // logic Of Reflection query

            sb.Append('}');
            return sb;
        }




    }
}
