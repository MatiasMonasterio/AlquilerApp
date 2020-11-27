// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// DEPARTAMENT INFO REGISTER
if( typeof addDeparment != "undefined" ){
    let cantDepto = 1;

    addDeparment.addEventListener('click', () => {
        const ElementToRepeat = document.querySelector('#deparmentForm').firstElementChild;
        const cloneElement = ElementToRepeat.cloneNode(true);
    
        cantDepto += 1;
        cloneElement.firstElementChild.innerText = `Departamento 0${ cantDepto }`;
        
        deparmentForm.insertBefore( cloneElement , addDeparment );
    });
}


// SIDEBAR
if( typeof sidebarButton != "undefined" ){
    sidebarButton.addEventListener('click', () => {
        const sidebar = document.querySelector('#sidebar');
        sidebar.classList.toggle('sidebar-show-transition');
    });
    
    sidebarDerparmentsButton.addEventListener('click', () =>{
        departmentListBox.classList.toggle('deparment-list-show');
        sidebarDerparmentsButton.classList.toggle('sidebar__department-button');
    });
}


// DEPARTMENT PAGE
if( typeof deparmetnOptions != "undefined" ){
    deparmetnOptions.addEventListener('click', () => {
        deparmetnOptionsDropdown.classList.toggle('d-flex')
    });

    const feeButtonList = document.querySelectorAll('[data-button]');
    feeButtonList.forEach( element => {
        element.addEventListener('click', () =>{
            feeDetailsContainer.classList.add('showFeeDetailsContainer');
        });
    });

    feeDetailsButton.addEventListener('click', () => {
        feeDetailsContainer.classList.remove('showFeeDetailsContainer');
    });

    paidDropdownButton.addEventListener('click', () => {
        paidDropdownContainer.classList.toggle('d-none');
        paidDropdownButton.classList.toggle('deparment-container-expand')
    });
}











