# R2 Wezhfny API — Learning Roadmap

## Current Project Structure

```
Backend/
├── Models/
│   ├── User.cs
│   ├── JobCategory.cs             ← Many-to-many with Job
│   ├── Company.cs
│   ├── Job.cs                     ← Many-to-many with Category
│   ├── Resume.cs
│   └── Application.cs             ← NEW: Job applications
├── Data/
│   └── AppDbContext.cs            ← Updated: Applications DbSet + config
├── DTOs/
│   ├── Auth/                      ← RegisterDto, LoginDto, UserResponseDto
│   ├── Jobs/                      ← JobDto, CreateJobDto, JobFilterDto
│   ├── Companies/                 ← CompanyDto, CreateCompanyDto
│   ├── Categories/
│   │   ├── CategoryDto.cs
│   │   └── CreateCategoryDto.cs   ← NEW
│   ├── Resumes/                   ← ResumeDto, CreateResumeDto, UpdateResumeDto
│   ├── Applications/              ← NEW: ApplicationDto, CreateApplicationDto, UpdateApplicationStatusDto
│   ├── Users/                     ← NEW: UserDto, UpdateUserDto
│   └── Stats/                     ← NEW: (inline in controller)
├── Interfaces/
│   ├── IRepository.cs             ← Generic CRUD
│   ├── IJobRepository.cs
│   ├── ICompanyRepository.cs
│   ├── ICategoryRepository.cs
│   ├── IResumeRepository.cs
│   ├── IUserRepository.cs
│   └── IApplicationRepository.cs  ← NEW
├── Repositories/
│   ├── Repository.cs
│   ├── JobRepository.cs
│   ├── CompanyRepository.cs
│   ├── CategoryRepository.cs
│   ├── ResumeRepository.cs
│   ├── UserRepository.cs
│   └── ApplicationRepository.cs   ← NEW
├── Services/
│   ├── IJobService.cs / JobService.cs       ← Added UpdateAsync
│   ├── ICompanyService.cs / CompanyService.cs ← Added Create/Update/Delete
│   ├── ICategoryService.cs / CategoryService.cs ← Added Create/Update/Delete
│   ├── IResumeService.cs / ResumeService.cs
│   ├── IApplicationService.cs / ApplicationService.cs ← NEW
│   └── IUserService.cs / UserService.cs       ← NEW
├── Controllers/                   ← NEW: Step 9
│   ├── JobsController.cs
│   ├── CompaniesController.cs
│   ├── CategoriesController.cs
│   ├── ResumesController.cs
│   ├── ApplicationsController.cs   ← NEW: Extended
│   ├── UsersController.cs          ← NEW: Extended
│   └── StatsController.cs          ← NEW: Extended
├── Migrations/
├── Program.cs                     ← Updated: all services + repos registered
├── NextSteps.md
└── Backend.csproj
```

---

## ✅ Completed Steps

- **Step 1**: Create Web API project ✅
- **Step 2**: Create Models ✅
- **Step 3**: Create DbContext ✅
- **Step 4**: Configure connection string + register in Program.cs ✅
- **Step 5**: Run migration to create database ✅
- **Step 6**: Create DTOs ✅
- **Step 7**: Repository Pattern ✅
- **Step 8**: Services (Business Logic) ✅
- **Step 9**: Controllers (API Endpoints) ✅
- **Extended Endpoints** ✅

---

## ✅ Step 9: Controllers (API Endpoints)

Created 7 controllers with full CRUD:

### JobsController — `api/jobs`
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/jobs` | List all jobs (with query filters: `search`, `categoryIds`, `locationType`, `companyId`, `minSalary`, `maxSalary`) |
| GET | `/api/jobs/{id}` | Get job by ID (includes company name + category names) |
| POST | `/api/jobs` | Create a new job (requires `CategoryIds` list) |
| PUT | `/api/jobs/{id}` | Update a job (including categories) |
| DELETE | `/api/jobs/{id}` | Delete a job |

### CompaniesController — `api/companies`
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/companies` | List all companies (includes `openJobsCount`) |
| GET | `/api/companies/{id}` | Get company by ID |
| POST | `/api/companies` | Add a new company |
| PUT | `/api/companies/{id}` | Update company |
| DELETE | `/api/companies/{id}` | Delete company |

### CategoriesController — `api/categories`
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/categories` | List all categories (returns `id`, `name`, `nameAr`) |
| POST | `/api/categories` | Add a new category |
| PUT | `/api/categories/{id}` | Update category |
| DELETE | `/api/categories/{id}` | Delete category |

### ResumesController — `api/resumes`
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/resumes/user/{userId}` | List all resumes for a user |
| GET | `/api/resumes/{id}` | Get resume by ID |
| POST | `/api/resumes` | Create a new resume |
| PUT | `/api/resumes/{id}` | Update resume |
| DELETE | `/api/resumes/{id}` | Delete resume |

---

## ✅ Extended Endpoints

### ApplicationsController — `api/applications`
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/applications/job/{jobId}` | See all applicants for a job |
| GET | `/api/applications/user/{userId}` | See a user's applications |
| GET | `/api/applications/{id}` | Get application by ID |
| POST | `/api/applications` | Apply for a job |
| PATCH | `/api/applications/{id}/status` | Update application status (e.g., "قيد المراجعة" → "مقبول") |
| DELETE | `/api/applications/{id}` | Delete an application |

### UsersController — `api/users`
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/users/{id}` | Get user profile |
| PUT | `/api/users/{id}` | Update user profile (name, email) |

### StatsController — `api/stats`
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/stats` | Dashboard stats: `totalJobs`, `totalCompanies`, `totalCategories`, `totalApplications`, `totalUsers` |

---

## 🔍 Q&A

### Q: How do categories work when posting a job?

Categories are **predefined** in the `JobCategories` table. They are not free-text typed by the company. When a company posts a job:

1. They see a list of existing categories fetched from `GET /api/categories`
2. They select one or more categories from that list
3. The selected category IDs are sent in `CreateJobDto.CategoryIds` (an array of ints)

**Example request body for creating a job:**
```json
{
  "title": "مطور فول ستاك",
  "description": "...",
  "skills": "React, Node.js",
  "location": "الرياض",
  "locationType": "في الموقع",
  "salary": 15000,
  "companyId": 1,
  "categoryIds": [1, 3]
}
```

- If no categories fit, an admin can add new ones via `POST /api/categories`
- A job can belong to multiple categories (many-to-many)
- The response returns `categoryNames` (Arabic names) for display

### Q: How does the many-to-many Job ↔ Category work now?

```
Jobs:      Full Stack Developer  ─┐
                                  ├──→ JobJobCategory → Programming
JobCategories:                    ├──→ JobJobCategory → Design
           UI/UX Designer ────────┘
```

The join table `JobJobCategory` is created automatically by EF Core.

### Q: What can the user search by?

```
GET /api/jobs?search=developer&categoryIds=1&categoryIds=3
              &locationType=عن بعد&companyId=1
              &minSalary=5000&maxSalary=10000
```

The text `search` checks: **Title, Description, Skills, Location, and Company Name** — everything at once.

---

## How to Run

```bash
cd Backend

# Apply latest migration (adds Applications table)
dotnet ef database update

# Start the API
dotnet run
```

The API will be available at `http://localhost:5000` or `https://localhost:5001`.

---

## 📋 Next Steps (Optional / Future)

- **Step 10**: JWT Authentication — protect endpoints with login/register
- **Step 11**: Testing with Swagger or Postman
- **Step 12**: Frontend integration — connect Angular static components to live API
- **Step 13**: Image upload for company logos
- **Step 14**: Pagination for jobs list
