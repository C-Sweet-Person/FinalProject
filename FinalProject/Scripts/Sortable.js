var Sortable = {
    baseUrl: '',
    sortBy: 0,
    searchterm: '',
    Sort(sortBy) {
        console.log("Sort");
        window.location.href = Sortable.baseUrl + "?sortBy=" + sortBy;
    }
};