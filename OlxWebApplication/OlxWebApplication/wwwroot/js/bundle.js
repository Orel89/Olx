// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function selected_category(categoryName, categoryId)
{
    debugger;
    if( categoryName == null) {
        categoryName = "test";
        }
    document.querySelector(".categoryName").value = categoryName;
    document.querySelector(".categoryId").value = categoryId;
};