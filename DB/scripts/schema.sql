CREATE TABLE USER(
    Id bigint auto_increment not NULL PRIMARY KEY,
    Name NVARCHAR(100) not NULL,
    IntVal int NULL
)

CREATE TABLE UsersItem(
    Id bigint auto_increment not NULL PRIMARY KEY,
    UserId bigint not null,
    ItemName NVARCHAR(100) not NULL
)