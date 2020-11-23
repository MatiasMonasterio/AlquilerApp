// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// SIDEBAR
sidebarButton.addEventListener('click', () => {
    sidebar.classList.toggle('sidebar-show-transition');
});

sidebarDerparmentsButton.addEventListener('click', () =>{
    departmentListBox.classList.toggle('deparment-list-show');
    sidebarDerparmentsButton.classList.toggle('sidebar__department-button');
});





const feeButtonList = document.querySelectorAll('[data-button]');
feeButtonList.forEach( element => {
    element.addEventListener('click', () =>{
        feeDetailsContainer.classList.add('showFeeDetailsContainer');
    });
})

feeDetailsButton.addEventListener('click', () => {
    feeDetailsContainer.classList.remove('showFeeDetailsContainer');
});