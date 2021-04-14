// Result class for representing the correct, and the received results of the test


namespace SkillTest
{
    public class Result
    {
        private string[] CorrectResults;   // The expected results
        private string[] ReceivedResults;  // The received results
        public int GazeNumber { get; }     // The gaze number of the current test, and the length of the result arrays


        // In the constructor set the number of array elements, and fill up the arrays with null values
        public Result(int gazeNumber)
        {
            this.CorrectResults = new string[gazeNumber];
            this.ReceivedResults = new string[gazeNumber];
            this.GazeNumber = gazeNumber;
        }


        // Getter, and setter for CorrectResults
        public string getCorrectResults(int index)
        {
            return this.CorrectResults[index];
        }

        public void setCorrectResults(int index, string value)
        {
            this.CorrectResults[index] = value;
        }

        // Getter, and setter for ReceivedResults
        public string getReceivedResults(int index)
        {
            return this.ReceivedResults[index];
        }

        public void setReceivedResults(int index, string value)
        {
            this.ReceivedResults[index] = value;
        }

        // Function for get the number of correct directions
        public int getNumericResult()
        {
            int resultNumber = 0;

            for (int i=0; i<this.GazeNumber; i++)
            {
                if (this.CorrectResults[i] == this.ReceivedResults[i])
                {
                    resultNumber++;
                }
            }

            return resultNumber;
        }
    }
}
