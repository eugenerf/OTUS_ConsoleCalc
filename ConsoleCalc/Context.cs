using System.Collections.Generic;

namespace ConsoleCalc
{
    class Context
    {
        Dictionary<string, double> variables;
        
        public Context()
        {
            variables = new Dictionary<string, double>();
        }

        /// <summary>
        /// Gets the specified variable value
        /// </summary>
        /// <param name="name">Variable name</param>
        /// <returns></returns>
        public double GetVariable(string name)
        {
            return variables[name];
        }

        /// <summary>
        /// Sets the existing variable value or adds a new variable
        /// </summary>
        /// <param name="value">Variable value</param>
        /// <returns>Adde variable name</returns>
        public string AddVariable(double value)
        {
            string name = "op" + variables.Count.ToString();

            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);

            return name;
        }
    }
}
