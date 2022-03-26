function GridItem(isHeader, text, link, imgSrc){
    this.isHeader = isHeader;
    this.text = text;
    this.link = link;
    this.imgSrc = imgSrc;
}

const app = Vue.createApp({
    data() {
        return {
            mainGridItems: [
                new GridItem(true, "ULearn Basics - Viewing Trainings, Taking Quizzes"),
                new GridItem(false, "Using the Employee Dashboard", "view-progress/employee_dashboard.html", "images/view-progress/employee-dashboard.jpg"),
                new GridItem(true, "View Your Personal Training Record"),
                new GridItem(false, "View Completed Trainings", "view-progress/view_own.html", "images/view-progress/view-own.jpg"),
                new GridItem(true, "Approving Trainings For Employees That Took More Than The Allowed Quiz Attempts"),
                new GridItem(false, "Using the Management Homepage", "management-dash/home.html", "images/management-dash/home.jpg"),
                new GridItem(true, "Assigning Trainings"),
                new GridItem(false, "Assign To Employee(s)", "assign-trainings/assign-training-to-employee.html", "images/assign-trainings/assign-by-employee-icon.jpg"),
                new GridItem(false, "Assign To Employees by Department", "assign-trainings/assign-employee-department.html", "images/assign-trainings/assign-by-employee-department-icon.jpg"),
                new GridItem(false, "Assign To Department", "assign-trainings/assign-department.html", "images/assign-trainings/assign-by-department.jpg"),
                new GridItem(true, "Viewing Department Information (Assigned Trainings, Child Departments, Employees, and Job Titles)"),
                new GridItem(false, "Department Overview", "department-info/department_info.html", "images/department-info/trainings-assigned-employees.jpg"),
                new GridItem(true, "Unassigning Trainings"),
                new GridItem(false, "Unassign Trainings", "unassign-trainings/unassign.html", "images/unassign-training/unassign.jpg"),
                new GridItem(true, "Adding, Removing, and Editing Employees"),
                new GridItem(false, "Adding Employees", "employees/add_employee.html", "images/employee/add-employee.jpg"),
                new GridItem(false, "Removing Employees", "employees/remove_employee.html", "images/employee/remove-employee.jpg"),
                new GridItem(false, "Editing Employees/Password Reset", "employees/edit_employee.html", "images/employee/edit-employee.jpg"),
                new GridItem(true, "Adding and Editing Departments"),
                new GridItem(false, "Add a New Department", "department/add_department.html", "images/department/add.jpg"),
                new GridItem(false, "Edit a Department", "department/edit_department.html", "images/department/edit.jpg"),
                new GridItem(true, "View Training Progress for Department or Employee (View Past Due, Upcoming, and Completed Trainings)"),
                new GridItem(false, "View Training Records by Department", "view-progress/view_progress.html", "images/view-progress/view-progress.jpg"),
                new GridItem(false, "View Training Records by Employee(s)", "view-progress/view_employee_progress.html", "images/view-progress/view-employee-progress.jpg"),
                new GridItem(false, "View Comprehensive Training History", "view-progress/comprehensive_view.html", "images/view-progress/comprehensive.jpg"),
                new GridItem(true, "Create, Replace, or Archive a Training"),
                new GridItem(false, "Create a New Training", "training/create_training.html", "images/training/create-training.jpg"),
                new GridItem(false, "Replace an Existing Training", "training/replace_training.html", "images/training/replace-training.jpg"),
                new GridItem(false, "Archive a Training", "training/archive_training.html", "images/training/archive-training.jpg"),
                new GridItem(true, "Create/Edit a Training Quiz"),
                new GridItem(false, "Create/Replace a Training Quiz", "quiz/create_replace.html", "images/quiz/create-replace.jpg"),
            ],
        };
    },

    methods: {
        
        navigate(url){
            window.location = url;
        },

    },


    computed: {

    }
});

const vm = app.mount("#app-root");