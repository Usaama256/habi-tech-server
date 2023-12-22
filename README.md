# Habi-Tech Live Server
The Perfect solution for your automation, Is made up of two componets; the client and the server.
The Server is an ASP.NET Web Api imlementation built with C#
## Live Demo
<a href="https://habitech.azurewebsites.net/">Live Preview</a>

### Login Test Credentials
```
{
  "Email": "sama.dev@habitech.iot",
  "Pass": "!wa30~03dq#"
}
```
```
{
   "Email": "test.dev@habitech.iot",
   "Pass": "03dq#~!wa30"
}
```
## API Test and Documentation
### User
<a href="https://app.swaggerhub.com/apis-docs/USAAMANKANGI/User/1.0.0#/default/post_habitech_api_login">View Docs</a>

### Lights
<a href="https://app.swaggerhub.com/apis-docs/USAAMANKANGI/Lights/1.0.0#/default/get_habitech_api_switchlight__device_id___action___user_Id_">View Docs</a>

### Program Structure
```plaintext
- habi-tech_server
  - docs
  - HabiTech
    - bin
      - Debug
        - net8.0
    - Controllers
    - Database
    - Models
    - obj
      - Debug
        - net8.0
    - Properties
    - Services
    - wwwroot
  - Habitech.Contracts
    - bin
      - Debug
        - net8.0
    - Lights
    - obj
      - Debug
        - net8.0
    - User
  - requests
    - lights
    - user
  - sql
```
### Local Setup
To get a local copy of the code, clone it using git:

```
git clone https://github.com/Usaama256/habi-tech-server.git
cd ./habi-tech-server
```
Install dependencies:

```
#
```

Now, you can start a local web server by running:

```
dotnet run --project ./HabiTech
```

And then open http://localhost:5014 to view it in the browser.

## Database Setup
Create a database with the following tables and link its details in 'habi-tech-all/habi-tech_server/HabiTech/Database/DBConnection.cs'
## 1. user
Contains All users' details
### Structure
```
| Field            | Type              | Null | Key | Default                        | Extra                                        |
|------------------|-------------------|------|-----|--------------------------------|----------------------------------------------|
| user_id          | int               | NO   | PRI | NULL                           | auto_increment                               |
| username         | varchar(255)      | NO   | UNI | NULL                           |                                              |
| profile_picture  | varchar(255)      | YES  | UNI | NULL                           |                                              |
| pass             | varchar(550)      | NO   |     | NULL                           |                                              |
| email            | varchar(255)      | YES  | UNI | NULL                           |                                              |
| created_at       | timestamp         | YES  |     | CURRENT_TIMESTAMP              | DEFAULT_GENERATED                            |
| updated_at       | timestamp         | YES  |     | CURRENT_TIMESTAMP              | DEFAULT_GENERATED on update CURRENT_TIMESTAMP|
| salt             | varchar(255)      | YES  |     | NULL                           |                                              |

```
### Create Statement
```
CREATE TABLE user (
  user_id INT NOT NULL AUTO_INCREMENT,
  username VARCHAR(255) NOT NULL UNIQUE,
  profile_picture VARCHAR(255) UNIQUE,
  pass VARCHAR(550) NOT NULL,
  email VARCHAR(255) UNIQUE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  salt VARCHAR(255),
  PRIMARY KEY (user_id)
);
```
## 2. device_type
Contains All device categories
### Structure
```
| Field            | Type          | Null | Key | Default                        | Extra                                        |
|------------------|---------------|------|-----|--------------------------------|----------------------------------------------|
| type_id          | int           | NO   | PRI | NULL                           | auto_increment                               |
| type_name        | varchar(255)  | NO   | UNI | NULL                           |                                              |
| type_description | varchar(255)  | YES  |     | NULL                           |                                              |
| created_at       | timestamp     | YES  |     | CURRENT_TIMESTAMP              | DEFAULT_GENERATED                            |
| updated_at       | timestamp     | YES  |     | CURRENT_TIMESTAMP              | DEFAULT_GENERATED on update CURRENT_TIMESTAMP|

```
### Create Statement
```
CREATE TABLE device_type (
  type_id INT NOT NULL AUTO_INCREMENT,
  type_name VARCHAR(255) NOT NULL UNIQUE,
  type_description VARCHAR(255),
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (type_id)
);

```
## 3. device
Contains All devices
### Structure
```
| Field              | Type                              | Null | Key | Default            | Extra            |
|--------------------|-----------------------------------|------|-----|--------------------|------------------|
| device_id          | int                               | NO   | PRI | NULL               | auto_increment   |
| user_id            | int                               | YES  | MUL | NULL               |                  |
| type_id            | int                               | YES  | MUL | NULL               |                  |
| status             | enum('ON','OFF')                  | YES  |     | OFF                |                  |
| created_at         | timestamp                         | YES  |     | CURRENT_TIMESTAMP  | DEFAULT_GENERATED|
| device_name        | varchar(255)                      | NO   |     | NULL               |                  |
| device_description | varchar(255)                      | YES  |     | NULL               |                  |

```
### Create Statement
```
CREATE TABLE device (
  device_id INT NOT NULL AUTO_INCREMENT,
  user_id INT,
  type_id INT,
  status ENUM('ON', 'OFF') DEFAULT 'OFF',
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  device_name VARCHAR(255) NOT NULL,
  device_description VARCHAR(255),
  PRIMARY KEY (device_id),
  FOREIGN KEY (user_id) REFERENCES user(user_id),
  FOREIGN KEY (type_id) REFERENCES device_type(type_id)
);

```
# All Credits To <a href='http://bit.ly/nkangi'>Usaama Nkangi</a>

