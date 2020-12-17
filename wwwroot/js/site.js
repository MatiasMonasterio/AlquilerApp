// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const heightFixed = () => {
    const doc = document.documentElement;
    doc.style.setProperty('--vh', `${window.innerHeight}px`);
}
heightFixed();
window.addEventListener('resize', heightFixed)

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


// DEPARTMENT LESSEE
if( typeof lesseeDepartment != "undefined" ){
    deparmetnOptions.addEventListener('click', () => {
        deparmetnOptionsDropdown.classList.toggle('d-flex')
    });

    const feeButtonList = document.querySelectorAll('[data-button]');
    feeButtonList.forEach( element => {
        element.addEventListener('click', () =>{
            feeDetailsContainer.classList.add('showFeeDetailsContainer');

            let feeId = element.dataset.feeId;
            let urlSearchParam = new URLSearchParams( window.location.search );
            let departmentId = urlSearchParam.get('id');
            let localurl = `${window.location.origin}/LesseeAPI/GetFee?idFee=${feeId}&idDepartment=${departmentId}`;

            fetch( localurl )
                .then( response => response.json() )
                .then( data => feeDetailsUI( data ) );
        });
    });

    feeDetailsButton.addEventListener('click', () => {
        feeDetailsContainer.classList.remove('showFeeDetailsContainer');
    });

    paidDropdownButton.addEventListener('click', () => {
        paidDropdownContainer.classList.toggle('d-none');
        paidDropdownButton.classList.toggle('deparment-container-expand')
    });

    AditionalAmountForm.addEventListener('submit', (e) => {
        e.preventDefault();
        let description = aditionalDescription.value;
        let amount = aditionalAmount.value;
        let feeId = aditionalFeeId.value;
        let url = `${window.location.origin}/LesseeAPI/AddAditionalAmount`;

        let AdicionalAmount = {
            Description: description,
            amount: amount,
            feeId: feeId
        }

        fetch( url, {
            method: 'POST',
            body: JSON.stringify( AdicionalAmount ),
            headers: {"Content-type": "application/json; charset=UTF-8"}
        })
        .then( () => {
            AditionalAmountForm.reset();
            closeAdionalAmountModal.click();
        });
    });
}

// DEPARTMENT RENTER
if( typeof renterDepartment != "undefined" ){
    const feeButtonList = document.querySelectorAll('[data-button]');
    feeButtonList.forEach( element => {
        element.addEventListener('click', () =>{
            feeDetailsContainer.classList.add('showFeeDetailsContainer');

            let feeId = element.dataset.feeId;
            let localurl = `${window.location.origin}/RenterAPI/GetFee?idFee=${feeId}`;

            fetch( localurl )
                .then( response => response.json() )
                .then( data => feeDetailsUI( data ) );
        });
    });

    feeDetailsButton.addEventListener('click', () => {
        feeDetailsContainer.classList.remove('showFeeDetailsContainer');
    });
}

function feeDetailsUI( feeData ){
    let title = document.querySelector("[data-title]");
    let state = document.querySelector("[data-state]");
    let expiryDate = document.querySelector("[data-expiry-date]");
    let amount = document.querySelector("[data-amount]");
    let total = document.querySelector("[data-total]");
    let sign = document.querySelector("[data-sign]");

    title.innerText = `Cuota ${ feeData.id.toPrecision() }`;
    expiryDate.innerText = `Vencimiento ${ moment( feeData.expiryDate ).locale('es').format("ddd D MMMM") }`;
    amount.innerText= `Monto $${ feeData.amount.toFixed(2).toString().replace(/\./g,',') }`;

    if( feeData.paymentDate == "0001-01-01T00:00:00" ) {
        state.innerText = 'Estado Pendiente';
        if( sign != null ) sign.classList.add('d-none');
        if( typeof confirmPay != "undefined" ) {
            let urlSearchParam = new URLSearchParams( window.location.search );
            let departmentId = urlSearchParam.get('id');

            confirmPay.href = `/lessee/confirmPayment?fee=${feeData.id}&department=${departmentId}`;
            confirmPay.classList.remove('d-none');
        }
    }
    else {
        state.innerText = 'Estado Pagado';
        if( sign != null ) {
            sign.classList.remove('d-none');
            signButtonUI( sign, feeData.sign );

            sign.addEventListener('click', () => {
                fetch(`/RenterAPI/SignFee?fee=${feeData.id}`)
                .then( () => signButtonUI( sign, true ) );
            });
        }
        if( typeof confirmPay != "undefined" ) confirmPay.classList.add('d-none');
    }
    total.innerText = `Total $${ new Intl.NumberFormat("es-AR").format( feeData.amount.toFixed(2) ) }`
}

function signButtonUI( element, sign ){

    if( sign ){
        element.disabled = true;
        element.innerText = 'Firmado';
        element.classList.add('bg-info');
    }
    else{
        element.disabled = false;
        element.innerText = 'Firmar';
        element.classList.remove('bg-info');
    }
}

// ACCOUNT
if( typeof accountButtonEdit != "undefined" ){
    accountButtonEdit.addEventListener('click', () => {
        accountOptions.classList.toggle('d-flex');
    });
}

// SETTINGS
if( typeof themeForm != "undefined" ){
    let value;
    let userRol;

    if( window.location.pathname.includes('lessee') ) userRol = 'LesseeAPI';
    else userRol = 'RenterAPI';

    toggleText(feeEmit);
    toggleText(feeOverdue);
    toggleText(feePayment);


    themeForm.addEventListener('change', () => {
        if( inputTheme.checked == true ) value = true
        else value = false

        let url = `${window.location.origin}/${userRol}/ChangeTheme?theme=${value}`;

        fetch( url );
    });

    feeEmit.addEventListener('change', () => {
        let url = `${window.location.origin}/${userRol}/ChnageAlertFeeEmit?value=${feeEmit.checked}`;
        fetch( url );
        toggleText(feeEmit);
    });

    feeOverdue.addEventListener('change', () => {
        let url = `${window.location.origin}/${userRol}/ChangeAlertFeeOverdue?value=${feeOverdue.checked}`;
        fetch( url );
        toggleText(feeOverdue);
    });

    feePayment.addEventListener('change', () => {
        let url = `${window.location.origin}/${userRol}/ChangePaymentTicket?value=${feePayment.checked}`;
        fetch( url );
        toggleText(feePayment);
    });
}

function toggleText( element ){
    if( element.checked == true ) element.nextElementSibling.innerText = 'Activado';
    else element.nextElementSibling.innerText = 'Desactivado';
};











