# Codebase task proposals

## 1) Typo fix task
**Task:** Fix the user-facing typo in the admin demotion success message.

- **Issue found:** The message says `hs been removed` instead of `has been removed`.
- **Where:** `app.py` in the admin dashboard flow.
- **Suggested acceptance criteria:**
  - Message text reads: `has been removed from admin.`
  - Manual verification via Streamlit admin UI path for demoting an admin user.

## 2) Bug fix task
**Task:** Normalize exam type values used by the Exams menu to prevent failed question retrieval.

- **Issue found:** One exam type label includes a leading space (`" ANALYTICAL REASONING"`), which can break DB lookup equality matching (`WHERE question_type = ?`).
- **Where:** `app.py` exam type list + `utilities.py` SQL filter logic.
- **Suggested acceptance criteria:**
  - All exam type identifiers used for DB queries are trimmed/normalized.
  - Selecting Analytical Reasoning returns available questions when matching rows exist.
  - Add regression test for whitespace/normalization behavior.

## 3) Code comment / documentation discrepancy task
**Task:** Update README project structure to match the actual repository contents.

- **Issue found:** README documents a `.streamlit/` directory in the project structure, but that directory is not present in this repository.
- **Where:** `README.md` project structure section.
- **Suggested acceptance criteria:**
  - README structure only lists tracked/expected directories that actually exist, or clearly labels optional directories as not included by default.

## 4) Test improvement task
**Task:** Add automated tests for role display mapping in the admin users table.

- **Issue found:** The admin table maps `Is Admin` with `x == "Yes"`, but role data appears to be stored as `admin`/`student`, making the current mapping fragile and likely incorrect.
- **Where:** `app.py` admin dashboard dataframe transformation and `utilities.py` `get_all_users` role sourcing.
- **Suggested acceptance criteria:**
  - Introduce tests that validate admin-role-to-boolean mapping for representative values (`admin`, `student`).
  - Refactor mapping logic to align with actual stored values.
  - Ensure non-admin users appear in the promotion list and admins are excluded.
