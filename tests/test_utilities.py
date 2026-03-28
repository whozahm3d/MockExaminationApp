import os
import sqlite3
import tempfile
import unittest

from utilities import UserDatabase


class UserDatabaseTests(unittest.TestCase):
    def setUp(self):
        fd, self.db_path = tempfile.mkstemp(suffix='.db')
        os.close(fd)
        self.db = UserDatabase(self.db_path)

    def tearDown(self):
        if os.path.exists(self.db_path):
            os.remove(self.db_path)

    def test_initialize_database_creates_expected_tables(self):
        conn = sqlite3.connect(self.db_path)
        try:
            cursor = conn.cursor()
            cursor.execute(
                "SELECT name FROM sqlite_master WHERE type='table' "
                "AND name IN ('Users','Questions','UserProgress','UserAnswers')"
            )
            tables = sorted([row[0] for row in cursor.fetchall()])
            self.assertEqual(tables, ['Questions', 'UserAnswers', 'UserProgress', 'Users'])
        finally:
            conn.close()

    def test_get_random_questions_trims_exam_type_whitespace(self):
        conn = sqlite3.connect(self.db_path)
        try:
            cursor = conn.cursor()
            cursor.execute(
                "INSERT INTO Questions "
                "(question_text, option_a, option_b, option_c, option_d, correct_answer, question_type) "
                "VALUES (?, ?, ?, ?, ?, ?, ?)",
                (
                    "What is 2 + 2?",
                    "1",
                    "2",
                    "3",
                    "4",
                    "D",
                    "ANALYTICAL REASONING",
                ),
            )
            conn.commit()
        finally:
            conn.close()

        questions = self.db.get_random_questions(" ANALYTICAL REASONING ", num_questions=1)
        self.assertEqual(len(questions), 1)
        self.assertEqual(questions[0][1], "What is 2 + 2?")


if __name__ == '__main__':
    unittest.main()
