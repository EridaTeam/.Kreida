CREATE TABLE Users (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,
	Password VARCHAR(32) NOT NULL,
	ImageUrl VARCHAR(200) NOT NULL
);

CREATE TABLE Topics (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) UNIQUE NOT NULL,
	ImageUrl VARCHAR(200) NOT NULL
);

CREATE TABLE Courses (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	ImageUrl VARCHAR(200) NOT NULL,
	PublishingDate DATE NOT NULL,
	TopicId INT FOREIGN KEY REFERENCES Topics(Id) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	CONSTRAINT NameTopicUserUnique UNIQUE(Name, TopicId, UserId)
);

CREATE TABLE Lessons (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	ImageUrl VARCHAR(200) NOT NULL,
	VideoUrl VARCHAR(200) NOT NULL,
	CourseId INT FOREIGN KEY REFERENCES Courses(Id) ON DELETE CASCADE NOT NULL,
	CONSTRAINT NameCourseUnique UNIQUE(Name, CourseId)
);

CREATE TABLE Tests (
	Id INT IDENTITY PRIMARY KEY,
	ImageUrl VARCHAR(200) NOT NULL,
	CourseId INT UNIQUE FOREIGN KEY REFERENCES Courses(Id) ON DELETE CASCADE NOT NULL
);

CREATE TABLE Questions (
	Id INT IDENTITY PRIMARY KEY,
	Text VARCHAR(200) NOT NULL,
	FirstAnswer VARCHAR(100) NOT NULL,
	SecondAnswer VARCHAR(100) NOT NULL,
	ThirdAnswer VARCHAR(100) NOT NULL,
	ValidAnswer INT CHECK (ValidAnswer IN (1, 2, 3)) NOT NULL,
	TestId INT FOREIGN KEY REFERENCES Tests(Id) ON DELETE CASCADE NOT NULL
);