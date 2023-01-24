function selected_category(categoryName, categoryId)
{
    debugger;
    if( categoryName == null) {
        categoryName = "test";
        }
    document.querySelector(".categoryName").value = categoryName;
    document.querySelector(".categoryId").value = categoryId;
};