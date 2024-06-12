## Fiais WaveTalk Portal API

This documentation outlines the API endpoints and their rules.

### Authenticate

**Path:** `/auth`

**Method:** `POST`

**Request Body:**

```json
{
  "EmailOrUsername": "user1@example.com.br",
  "Password": "password"
}
```

**Business Rule:** Authenticate a user by their email or username and password. The email or username is case-insensitive and both will be validated to match.

**Success Response (201 Created):**

```json
{
  "success": true,
  "message": "Authentication successful",
  "data": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjAwMDAwMDAwLT..." // JWT token
}
```

**Error Responses:**

- **401 Unauthorized:** Incorrect email/username or password.
- **401 Unauthorized:** User is disabled.
- **401 Unauthorized:** Token expired or invalid.

### Create Chat Room

**Path:** `/chat-rooms`

**Method:** `POST`

**Request Body:**

```json
{
  "Description": "My Chat Room",
  "Password": "mysecret" // optional
}
```

**Business Rule:** Creates a new chat room. The description and password (optional) are trimmed. The password is encrypted if provided.

**Success Response (201 Created):**

```json
{
  "success": true,
  "message": "Chat Room created successfully"
}
```

**Error Responses:**

- **401 Unauthorized:** User not logged in or unauthorized.
- **400 Bad Request:** Invalid model state.
- **500 Internal Server Error:** Failure during the creation process.

### Get Chat Rooms

**Path:** `/chat-rooms`

**Method:** `GET`

**Business Rule:** Retrieves a collection of chat rooms, regardless of privacy.

**Success Response (200 OK):**

```json
{
  "success": true,
  "message": null,
  "data": [
    {
      "Id": "00000000-0000-0000-0000-000000000001",
      "CreatedAt": "2021-01-01T00:00:00",
      "Description": "Chat Room 1",
      "OwnerId": "00000000-0000-0000-0000-000000000011",
      "IsPrivate": true
    },
    {
      "Id": "00000000-0000-0000-0000-000000000002",
      "CreatedAt": "2021-01-02T00:00:00",
      "Description": "Chat Room 2",
      "OwnerId": "00000000-0000-0000-0000-000000000011",
      "IsPrivate": true
    },
    {
      "Id": "00000000-0000-0000-0000-000000000003",
      "CreatedAt": "2021-01-03T00:00:00",
      "Description": "Chat Room 3",
      "OwnerId": "00000000-0000-0000-0000-000000000012",
      "IsPrivate": false
    }
  ]
}
```

**Error Responses:**

- **401 Unauthorized:** User not logged in or unauthorized.
- **500 Internal Server Error:** Failure during the retrieval process.

### Get Chat Rooms by Logged User

**Path:** `/chat-rooms/user-logged`

**Method:** `GET`

**Business Rule:** Retrieves a collection of chat rooms accessible to the logged in user.

**Success Response (200 OK):**

````json
{
  "success": true,
  "message": null,
  "data": [
    {
      "Id": "00```json
     "0000-0000-0000-0000-000000000001",
      "AlternateId": "0001",
      "CreatedAt": "2021-01-01T00:00:00",
      "IsPrivate": true,
      "Description": "Chat Room 1",
      "OwnerUsername": "User1",
      "OwnerName": "User 1",
      "OwnerEmail": "user1@example.com.br",
      "Users": [
        {
          "Id": "00000000-0000-0000-0000-000000000011",
          "AlternateId": 1,
          "Email": "user1@example.com.br",
          "Name": "User 1",
          "Username": "User1"
        },
        {
          "Id": "00000000-0000-0000-0000-000000000012",
          "AlternateId": 2,
          "Email": "user2@example.com",
          "Name": "User 2",
          "Username": "User2"
        }
      ]
    },
    {
      "Id": "00000000-0000-0000-0000-000000000003",
      "AlternateId": "0003",
      "CreatedAt": "2021-01-03T00:00:00",
      "IsPrivate": false,
      "Description": "Chat Room 3",
      "OwnerUsername": "User2",
      "OwnerName": "User 2",
      "OwnerEmail": "user2@example.com",
      "Users": [
        {
          "Id": "00000000-0000-0000-0000-000000000011",
          "AlternateId": 1,
          "Email": "user1@example.com.br",
          "Name": "User 1",
          "Username": "User1"
        },
        {
          "Id": "00000000-0000-0000-0000-000000000012",
          "AlternateId": 2,
          "Email": "user2@example.com",
          "Name": "User 2",
          "Username": "User2"
        }
      ]
    }
  ]
}
````

**Error Responses:**

- **401 Unauthorized:** User not logged in or unauthorized.
- **500 Internal Server Error:** Failure during the retrieval process.

### Get Chat Room by Code

**Path:** `/chat-rooms/{code}`

**Method:** `GET`

**Path Parameters:**

- `code`: (string) The code of the chat room (a number formatted to 4 digits)

**Business Rule:** Retrieves a chat room based on the provided code. The code must be a number between 0001 and 9999.

**Success Response (200 OK):**

```json
{
  "success": true,
  "message": null,
  "data": {
    "Id": "00000000-0000-0000-0000-000000000001",
    "Description": "Chat Room 1",
    "OwnerName": "User 1",
    "IsPrivate": true
  }
}
```

**Error Responses:**

- **401 Unauthorized:** User not logged in or unauthorized.
- **404 Not Found:** Chat room not found with the specified code.
- **500 Internal Server Error:** Failure during the retrieval process.

### Get Messages by Chat Room

**Path:** `/messages/{id}`

**Method:** `GET`

**Path Parameters:**

- `id`: (Guid) The unique identifier of the chat room.

**Business Rule:** Retrieves a collection of messages within the specified chat room.

**Success Response (200 OK):**

```json
{
  "success": true,
  "message": null,
  "data": [
    {
      "Id": "00000000-0000-0000-0000-000000000111",
      "AlternateId": 1,
      "ChatRoomId": "00000000-0000-0000-0000-000000000001",
      "UserId": "00000000-0000-0000-0000-000000000011",
      "Username": "User1",
      "Content": "Message 1",
      "CreatedAt": "2021-01-01T00:00:00"
    },
    {
      "Id": "00000000-0000-0000-0000-000000000113",
      "AlternateId": 3,
      "ChatRoomId": "00000000-0000-0000-0000-000000000001",
      "UserId": "00000000-0000-0000-0000-000000000012",
      "Username": "User2",
      "Content": "Message 3",
      "CreatedAt": "2021-01-03T00:00:00"
    }
  ]
}
```

**Error Responses:**

- **401 Unauthorized:** User not logged in or unauthorized.
- **404 Not Found:** Chat room not found with the specified ID.
- **404 Not Found:** User is not a member of the chat room.
- **500 Internal Server Error:** Failure during the retrieval process.

### Create User

**Path:** `/users`

**Method:** `POST`

**Request Body:**

```json
{
  "Username": "newuser",
  "Email": "newuser@example.com",
  "Name": "New User",
  "Password": "newpassword"
}
```

**Business Rule:** Creates a new user account. All fields are required.

**Success Response (201 Created):**

```json
{
  "success": true,
  "message": "User created successfully"
}
```

**Error Responses:**

- **401 Unauthorized:** User not logged in or unauthorized.
- **400 Bad Request:** Invalid model state.
- **409 Conflict:** Username or email already in use.
- **500 Internal Server Error:** Failure during the creation process.

### Enter Chat Room

**Path:** `/users/enter-chat-room`

**Method:** `POST`

**Request Body:**

```json
{
  "ChatRoomId": "00000000-0000-0000-0000-000000000001",
  "Password": "mysecret" // optional, for private chat rooms
}
```

**Business Rule:** Allows a user to enter a chat room. The chat room's ID must be a valid existing chat room. If the chat room is private, a valid password must be provided.

**Success Response (201 Created):**

```json
{
  "success": true,
  "message": "User successfully added to chat room"
}
```

**Error Responses:**

- **401 Unauthorized:** User not logged in or unauthorized.
- **404 Not Found:** Chat room with the specified ID does not exist.
- **400 Bad Request:** Invalid chat room password provided.
- **409 Conflict:** User is already a member of the chat room.
- **500 Internal Server Error:** Failure during the process.

### Health Check

**Path:** `/health-check`

**Method:** `GET`

**Business Rule:** Returns a basic health check message with the current date and time.

**Success Response (200 OK):**

```json
{
  "success": true,
  "message": "Health Check - 2024-04-13T00:00:00",
  "data": null
}
```

**Error Responses:**

- **500 Internal Server Error:** Failure during the health check.
