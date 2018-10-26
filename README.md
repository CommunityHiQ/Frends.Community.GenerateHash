# Frends.Community.GenerateHash
FRENDS community task for generating strings to chosen HashAlgorithm type.

- [Installing](#installing)
- [Tasks](#tasks)
    - [GenerateHash](#generateHash)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)
- [License](#license)

# Installing
You can install the task via FRENDS UI Task view or you can find the nuget package from the following nuget feed
'https://www.myget.org/F/frends/api/v3'

# Tasks

## GenerateHash

Calculates hash from input using selected algorithm. Task support following algorithms: MD5, RIPEMD 160, SHA1, SHA 256, SHA 384, SHA 512, HMAC SHA 256 and HMAC SHA 512. 

### Task Properties

#### Input
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| InputString  | string | Input string to be hashed. | "some text to be hashed"|

#### Options
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| HashFunction  | enum(typeOf(Function)) | Generates input string to chosen HashAlgorithm type. | MD5|

### Result
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| HashResult| string  | Returns Result string. |be0a5b7c090f4e08902758d79cf1c9d2 |

# Building
Ensure that you have 'https://www.myget.org/F/frends/api/v3' added to your nuget feeds

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.GenerateHash.git`

Restore dependencies

`nuget restore FRENDS.Community.GenerateHash`

Rebuild the project

Run Tests with nunit. Tests can be found under

`Frends.Community.GenerateHash\bin\Release\Frends.Community.GenerateHash.Tests.dll`

Create a nuget package, eg.:

`nuget pack nuspec/FRENDS.Community.GenerateHash.nuspec`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log
| Version | Changes |
| ----- | ----- |
| 1.4.0 | Use Frends.Tasks.Attributes version 1.2.0 instead of 1.2.1, re-structured README.md |
| 1.5.0 | Added option to use HMAC SHA 512 |

# License
This project is licensed under the MIT License - see the LICENSE file for details