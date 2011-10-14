var Order = Backbone.Model.extend({
    baseUri: '/OrderManagement/order/',

    url: function () {
        if (this.isNew()) {
            return this.baseUri;
        } else {
            return this.baseUri + this.get('id');
        }
    }
});