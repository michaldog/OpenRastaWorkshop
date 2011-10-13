var App = Backbone.Router.extend({
    routes: {
        "": 'index'
    },

    initialize: function () {
        this.orderListView = new OrderListView({ collection: orders, el: "#orderList" });
    },

    index: function () {

    }
});

$(function (window) {
    var orders = new OrderList();
    orders.fetch();
    
    window.App = new App();
    Backbone.history.start();
});