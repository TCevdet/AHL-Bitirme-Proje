// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('btnSwitch').addEventListener('click', () => {
    if (document.body.classList.contains('dark')) {
        document.body.classList.remove('dark')
    }
    else {
        document.body.classList.add('dark')
    }
    document.getElementById('darkTheme').innerText = document.body.classList
})