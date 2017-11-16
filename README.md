- [FRENDS.Community.GenerateHash](#frends.community.generateHash)
   - [Installing](#installing)
   - [Building](#building)
   - [Contributing](#contributing)
   - [Documentation](#documentation)
     - [GenerateHash](#generateHash)
	 - [Task Properties](#taskproperties)
	   - [Input](#input)
	   - [Options](#options)
	   - [Example usage](#exampleusage)
	   - [Result](#result)

# FRENDS.Community.GenerateHash
FRENDS community task for generating strings to chosen HashAlgorithm type.

## Installing
You can install the task via FRENDS UI Task view or you can find the nuget package from the following nuget feed
'https://www.myget.org/F/frends/api/v3'

## Building
Ensure that you have 'https://www.myget.org/F/frends/api/v3' added to your nuget feeds

Clone a copy of the repo

git clone 'https://github.com/CommunityHiQ/FRENDS.Community.Encyption.git'

Restore dependencies

nuget restore FRENDS.Community.GenerateHash

Rebuild the project

Run Tests with nunit. Tests can be found under

FRENDS.Community.GenerateHash\bin\Release\FRENDS.Community.GenerateHash.Tests.dll

Create a nuget package, eg.:

`nuget pack nuspec/FRENDS.Community.GenerateHash.nuspec`

## Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

## Documentation

### GenerateHash

Calculates hash from input using selected algorithm.

### Task Properties

#### Input
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| InputString  | string | Input string to be hashed. | "some text to be hashed"|

#### Options
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| HashFunction  | enum(typeOf(Function)) | Generates input string to chosen HashAlgorithm type. | MD5|

#### Example usage

#### Result
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| HashResult| string  | Returns Result string. |be0a5b7c090f4e08902758d79cf1c9d2 |

## License
This project is licensed under the MIT License - see the LICENSE file for details