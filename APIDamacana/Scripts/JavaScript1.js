var ViewModel = function () {
    var self = this;
    self.carts = ko.observableArray();
    self.error = ko.observable();

    var cartsUri = '/api/carts/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCarts() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.books(data);
        });
    }

    // Fetch the initial data.
    getAllBooks();
};

ko.applyBindings(new ViewModel());

self.products = ko.observableArray();
self.newProduct = {
    Name: ko.observable(),
    Price: ko.observable(),
}

var productsUri = '/api/products/';

function getProducts() {
    ajaxHelper(authorsUri, 'GET').done(function (data) {
        self.products(data);
    });
}

getProducts();