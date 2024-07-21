$(document).ready(function () {
    // Actualizar la barra de progreso y la vista previa cuando se llenan los campos
    $('body').on('input change', 'input, select, textarea', function () {
        updateProgressBar();
        updatePreview();
    });

    // Función para actualizar la barra de progreso
    function updateProgressBar() {
        // Seleccionar todos los campos de entrada excepto los campos ocultos de token y otros campos irrelevantes
        const relevantInputs = $('input:not([type=hidden]), select, textarea');
        const totalInputs = relevantInputs.length;
        let filledInputs = 0;

        console.log('Total Inputs:', totalInputs); // Depuración: Mostrar el número total de campos

        // Contar los campos llenos
        relevantInputs.each(function () {
            const fieldName = $(this).attr('name') || $(this).attr('id') || 'undefined';
            const fieldValue = $(this).val();
            console.log('Checking field:', fieldName, 'Value:', fieldValue); // Depuración: Mostrar el nombre y valor de cada campo
            if (fieldValue !== '' && fieldValue !== null) {
                filledInputs++;
                console.log('Field is filled:', fieldName); // Depuración: Mostrar campo lleno
            }
        });

        console.log('Filled Inputs:', filledInputs); // Depuración: Mostrar el número de campos llenos

        // Calcular el porcentaje de progreso
        const progressPercentage = (filledInputs / totalInputs) * 100;
        $('#progressBar').css('width', progressPercentage + '%');
        $('#progressBar').attr('aria-valuenow', progressPercentage);
        $('#progressPercentage').text(Math.round(progressPercentage) + '%');

        // Cambiar el color de la barra de progreso y del texto según el porcentaje
        let color;
        if (progressPercentage <= 25) {
            color = '#dc3545'; // Rojo
        } else if (progressPercentage <= 50) {
            color = '#ffc107'; // Amarillo
        } else if (progressPercentage <= 75) {
            color = '#17a2b8'; // Azul
        } else {
            color = '#28a745'; // Verde
        }
        $('#progressBar').css('background-color', color);
        $('#progressPercentage').css('background-color', color);
        $('#progressPercentage').css('color', '#fff');
    }

    // Función para actualizar la vista previa en vivo
    function updatePreview() {
        $('#previewName').text($('input[name="Name"]').val() || 'Name: N/A');
        $('#previewAge').text($('input[name="Age"]').val() || 'Age: N/A');
        $('#previewPhone').text($('input[name="Phone"]').val() || 'Phone: N/A');
        $('#previewCountry').text($('#Country option:selected').text() || 'Country: N/A');
        $('#previewEmail').text($('input[name="Email"]').val() || 'Email: N/A');
        $('#previewAddress').text($('input[name="Address"]').val() || 'Address: N/A');
        $('#previewCity').text($('input[name="City"]').val() || 'City: N/A');

        // Vista previa de la imagen
        const imageInput = $('input[name="Image"]')[0];
        if (imageInput.files && imageInput.files[0]) {
            const reader = new FileReader();
            reader.onload = function (e) {
                $('#previewImage').html('<img src="' + e.target.result + '" class="img-fluid" alt="Image Preview" />');
            }
            reader.readAsDataURL(imageInput.files[0]);
        } else {
            $('#previewImage').text('Image: N/A');
        }
    }

    // Inicializar la barra de progreso y la vista previa al cargar la página
    updateProgressBar();
    updatePreview();

    // Función para agregar un nuevo bloque de empleo
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
        updateProgressBar(); // Actualizar la barra de progreso cuando se agrega un nuevo bloque
    }

    // Función para agregar un nuevo bloque de educación
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
        updateProgressBar(); // Actualizar la barra de progreso cuando se agrega un nuevo bloque
    }

    // Función para agregar un nuevo bloque de habilidades
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
        updateProgressBar(); // Actualizar la barra de progreso cuando se agrega un nuevo bloque
    }

    // Función para agregar un nuevo bloque de cursos
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
        updateProgressBar(); // Actualizar la barra de progreso cuando se agrega un nuevo bloque
    }

    // Función para adjuntar el evento de eliminación a los nuevos bloques
    function attachRemoveEvent() {
        document.querySelectorAll('.removeEmploymentBtn, .removeEducationBtn, .removeSkillBtn, .removeCourseBtn').forEach(function (button) {
            button.addEventListener('click', function () {
                button.closest('.card').remove();
                updateProgressBar();
                updatePreview();
            });
        });
    }

    // Eventos para añadir nuevos bloques
    document.getElementById('addEmploymentBtn').addEventListener('click', addEmployment);
    document.getElementById('addEducationBtn').addEventListener('click', addEducation);
    document.getElementById('addSkillBtn').addEventListener('click', addSkill);
    document.getElementById('addCourseBtn').addEventListener('click', addCourse);

    // Inicializar la barra de progreso y la vista previa al cargar la página
    updateProgressBar();
    updatePreview();
});
