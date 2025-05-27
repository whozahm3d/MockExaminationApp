# 🎓 Mock Examination App

**Mock Examination App** is a full-featured web-based exam platform developed using Streamlit. It allows users to register, log in, take randomized mock tests across multiple subjects, and track their progress. Admins can manage user roles and access the admin dashboard for user insights and control. This platform is ideal for students, educators, and institutions seeking a lightweight tool to simulate test environments.

---

## 📌 Overview

The app provides:
- A **clean UI** for students to take tests.
- **Secure user authentication** and session management.
- **Randomized questions** from multiple subject domains.
- **Immediate scoring** and feedback.
- **Progress tracking** per user.
- **Admin dashboard** for promoting users and reviewing activity.

---

## 🚀 Features

### 👥 User Management
- **Sign up / Login** with email, username, and password.
- Session-controlled interface based on user role (student/admin).
- Secure credential validation using a SQLite database.

### 📝 Mock Exam System
- Users can take exams in:
  - Verbal Ability
  - Analytical Reasoning
  - Quantitative Reasoning
  - Subject Knowledge
- Each exam:
  - Pulls random questions from the database.
  - Displays 4 options per question.
  - Accepts answers and calculates score on completion.

### 📊 Progress Dashboard
- Displays:
  - Total attempted questions
  - Correct answers
  - Success percentage
- Shows user profile info (username, email, role).

### 🛠️ Admin Panel
- View all users in a table.
- Promote/demote users as admins.
- Track statistics like:
  - Total questions attempted
  - Correct answers
  - Score history

### 📦 Additional Features
- Sidebar with navigation options.
- Logout confirmation prompt.
- Fully managed using Streamlit session state.

---

## 🧰 Technologies Used

- **Frontend/UI:** [Streamlit](https://streamlit.io/)
- **Backend:** Python
- **Database:** SQLite (via a custom `UserDatabase` class)
- **Data Handling:** Pandas
- **UI Component Library:** `streamlit-option-menu`

---

## 📁 Project Structure


---

## ⚙️ Installation and Setup

Follow these steps to get the app running locally:

1. **Clone the repository**

```bash
git clone https://github.com/your-username/mock-examination-app.git
cd mock-examination-app

