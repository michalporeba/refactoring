namespace Step09
{
    public abstract class StatementFormatter
    {
        private string _name = string.Empty;

        public void AddName(string name) => _name = name;
    }

    public class StringStatementFormatter : StatementFormatter
    {
        
    }
}