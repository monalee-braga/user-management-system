CREATE TABLE Users (
  Id INT IDENTITY(1, 1) PRIMARY KEY,
  -- ID do usuário, auto-incremento
  Name NVARCHAR(100) NOT NULL,
  -- Nome do usuário
  Password NVARCHAR(255) NOT NULL,
  -- Senha do usuário (armazenada de forma segura, com hash)
  Email NVARCHAR(255) NOT NULL UNIQUE,
  -- Email do usuário, único
  Permission NVARCHAR(50) NOT NULL,
  -- Permissão do usuário (admin ou standard)
  Phone NVARCHAR(20) NULL -- Telefone do usuário (opcional)
);
GO CREATE NONCLUSTERED INDEX IX_Users_Email ON Users(Email);
GO
INSERT INTO Users (Name, Password, Email, Permission, Phone)
VALUES (
    'John Doe',
    'hashed_password_example',
    'johndoe@example.com',
    'admin',
    '21997788998'
  );