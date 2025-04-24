# WC-Tool

This is a .NET CLI version of the classic Unix `wc` (word count) utility.  
Built as part of a coding challenge from [codingchallenges.fyi](https://codingchallenges.fyi/challenges/challenge-wc)

---

## Setup

1. Clone the repository.
2. Open `config.json` and set the `BaseFolder` path to the directory where your `.txt` file(s) are located:
   ```json
   {
     "BaseFolder": "C:\\Path\\To\\Your\\TextFileToScan"
   }
3. Build and run the project
4. What to type: ccwc command filename, example "ccwc -l test.txt".
5. Commands: 
 The tool accepts the following single-letter flags (you can combine them):

   | Flag | Description           |
   |------|-----------------------|
   | `-l` | Count the number of lines       |
   | `-w` | Count the number of words       |
   | `-c` | Count the number of bytes       |
   | `-m` | Count the number of characters  |

   You can combine flags in any order. For example:

   ```bash
   ccwc -l test.txt       # Line count only
   ccwc -w test.txt       # Word count only
   ccwc -cl test.txt      # Byte and line count
   ccwc -clwm test.txt    # All metrics
5. Using powershell example: Get-Content test.txt | dotnet run --project WCTool -- -l
6. Example output: 
ccwc -clw test.txt
   7145   58164   342190 test.txt
