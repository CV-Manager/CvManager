document.addEventListener('DOMContentLoaded', function () {
    document.body.addEventListener('input', function (event) {
        if (event.target.matches('input, select, textarea')) {
            updateProgressBar();
            updatePreview();
        }
    });

    function updateProgressBar() {
        const relevantInputs = document.querySelectorAll('input:not([type=hidden]), select, textarea');
        const totalInputs = relevantInputs.length;
        let filledInputs = 0;

        relevantInputs.forEach(input => {
            if (input.value.trim() !== '') {
                filledInputs++;
            }
        });

        const progressPercentage = (filledInputs / totalInputs) * 100;
        const progressBar = document.getElementById('progressBar');
        const progressPercentageText = document.getElementById('progressPercentage');

        progressBar.style.width = progressPercentage + '%';
        progressBar.setAttribute('aria-valuenow', progressPercentage);
        progressPercentageText.textContent = Math.round(progressPercentage) + '%';

        let color;
        if (progressPercentage <= 25) {
            color = '#dc3545';
        } else if (progressPercentage <= 50) {
            color = '#ffc107';
        } else if (progressPercentage <= 75) {
            color = '#17a2b8';
        } else {
            color = '#28a745';
        }

        progressBar.style.backgroundColor = color;
        progressPercentageText.style.backgroundColor = color;
        progressPercentageText.style.color = '#fff';
    }

    function updatePreview() {
        document.getElementById('previewName').textContent = document.querySelector('input[name="Name"]').value || 'Name: N/A';
        document.getElementById('previewAge').textContent = document.querySelector('input[name="Age"]').value || 'Age: N/A';
        document.getElementById('previewPhone').textContent = document.querySelector('input[name="Phone"]').value || 'Phone: N/A';
        document.getElementById('previewCountry').textContent = document.querySelector('#Country').selectedOptions[0]?.text || 'Country: N/A';
        document.getElementById('previewEmail').textContent = document.querySelector('input[name="Email"]').value || 'Email: N/A';
        document.getElementById('previewAddress').textContent = document.querySelector('input[name="Address"]').value || 'Address: N/A';
        document.getElementById('previewCity').textContent = document.querySelector('input[name="City"]').value || 'City: N/A';

        const imageInput = document.querySelector('input[name="Image"]');
        if (imageInput && imageInput.files && imageInput.files[0]) {
            const reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById('previewImage').innerHTML = `<img src="${e.target.result}" class="img-fluid" alt="Image Preview" />`;
            }
            reader.readAsDataURL(imageInput.files[0]);
        } else {
            document.getElementById('previewImage').textContent = 'Image: N/A';
        }
    }

    function addEmployment() {
        const employmentContainer = document.getElementById('employmentContainer');
        const employmentHtml = `
            <div class="card mb-3">
                <div class="card-body">
                    <div class="form-group mb-3">
                        <label>Job Title</label>
                        <div class="input-group">
                            <input name="EmploymentHistories[][JobTitle]" class="form-control" placeholder="Job Title" />
                        </div>
                        <div class="form-text">e.g. Software Engineer</div>
                    </div>
                    <div class="form-group mb-3">
                        <label>Company</label>
                        <div class="input-group">
                            <input name="EmploymentHistories[][Company]" class="form-control" placeholder="Company" />
                        </div>
                        <div class="form-text">e.g. Google</div>
                    </div>
                    <div class="form-group mb-3">
                        <label>Start Date</label>
                        <div class="input-group">
                            <input type="date" name="EmploymentHistories[][StartDate]" class="form-control" />
                        </div>
                    </div>
                    <div class="form-group mb-3">
                        <label>End Date</label>
                        <div class="input-group">
                            <input type="date" name="EmploymentHistories[][EndDate]" class="form-control" />
                        </div>
                    </div>
                    <button type="button" class="btn btn-danger removeEmploymentBtn">Remove</button>
                </div>
            </div>`;
        employmentContainer.insertAdjacentHTML('beforeend', employmentHtml);
        attachRemoveEvent();
        updateProgressBar();
    }

    function addEducation() {
        const educationContainer = document.getElementById('educationContainer');
        const educationHtml = `
            <div class="card mb-3">
                <div class="card-body">
                    <div class="form-group mb-3">
                        <label>Institution</label>
                        <div class="input-group">
                            <input name="Educations[][Institution]" class="form-control" placeholder="Institution" />
                        </div>
                        <div class="form-text">e.g. Harvard University</div>
                    </div>
                    <div class="form-group mb-3">
                        <label>Title</label>
                        <div class="input-group">
                            <input name="Educations[][Title]" class="form-control" placeholder="Title" />
                        </div>
                        <div class="form-text">e.g. Bachelor of Science</div>
                    </div>
                    <div class="form-group mb-3">
                        <label>Start Date</label>
                        <div class="input-group">
                            <input type="date" name="Educations[][StartDate]" class="form-control" />
                        </div>
                    </div>
                    <div class="form-group mb-3">
                        <label>End Date</label>
                        <div class="input-group">
                            <input type="date" name="Educations[][EndDate]" class="form-control" />
                        </div>
                    </div>
                    <button type="button" class="btn btn-danger removeEducationBtn">Remove</button>
                </div>
            </div>`;
        educationContainer.insertAdjacentHTML('beforeend', educationHtml);
        attachRemoveEvent();
        updateProgressBar();
    }

    function addSkill() {
        const skillsContainer = document.getElementById('skillsContainer');
        const skillHtml = `
            <div class="card mb-3">
                <div class="card-body">
                    <div class="form-group mb-3">
                        <label>Skill</label>
                        <div class="input-group">
                            <input name="Skills[][SkillName]" class="form-control" placeholder="Skill" />
                        </div>
                        <div class="form-text">e.g. JavaScript</div>
                    </div>
                    <button type="button" class="btn btn-danger removeSkillBtn">Remove</button>
                </div>
            </div>`;
        skillsContainer.insertAdjacentHTML('beforeend', skillHtml);
        attachRemoveEvent();
        updateProgressBar();
    }

    function addCourse() {
        const coursesContainer = document.getElementById('coursesContainer');
        const courseHtml = `
            <div class="card mb-3">
                <div class="card-body">
                    <div class="form-group mb-3">
                        <label>Course</label>
                        <div class="input-group">
                            <input name="Courses[][Course]" class="form-control" placeholder="Course" />
                        </div>
                        <div class="form-text">e.g. Data Science</div>
                    </div>
                    <div class="form-group mb-3">
                        <label>Institution</label>
                        <div class="input-group">
                            <input name="Courses[][Institution]" class="form-control" placeholder="Institution" />
                        </div>
                        <div class="form-text">e.g. MIT</div>
                    </div>
                    <button type="button" class="btn btn-danger removeCourseBtn">Remove</button>
                </div>
            </div>`;
        coursesContainer.insertAdjacentHTML('beforeend', courseHtml);
        attachRemoveEvent();
        updateProgressBar();
    }

    function attachRemoveEvent() {
        document.querySelectorAll('.removeEmploymentBtn, .removeEducationBtn, .removeSkillBtn, .removeCourseBtn').forEach(button => {
            button.addEventListener('click', function () {
                button.closest('.card').remove();
                updateProgressBar();
                updatePreview();
            });
        });
    }

    document.getElementById('addEmploymentBtn').addEventListener('click', addEmployment);
    document.getElementById('addEducationBtn').addEventListener('click', addEducation);
    document.getElementById('addSkillBtn').addEventListener('click', addSkill);
    document.getElementById('addCourseBtn').addEventListener('click', addCourse);

    updateProgressBar();
    updatePreview();
});