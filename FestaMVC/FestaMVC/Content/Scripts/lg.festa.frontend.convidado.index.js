var lg = {festa:{frontend:{convidado:{}}}}

lg.festa.frontend.convidado.index = function($el) {
    if(!$el) {
        throw("Element invalid!")
    }

    this.$el = $el
    this.db = new Store("convidados")

    this.init()
}


lg.festa.frontend.convidado.index.prototype = {
    init: function() {
        this.$elGrid = this.$el[0].parentElement.querySelector("[name='grid']")
        this.$elTotal = this.$elGrid.parentElement.querySelector("tfoot > tr > th > span")

        this.loadGrid()
        this.initEvents()
    },
    loadGrid: function() {
        var elTBody = this.$elGrid.parentElement.querySelector("tbody")
        var list = this.db.get()

        var tbody = list.reduce(function(row, convidado) {
            row = row.concat("<tr class='item'><td>"
                     .concat(festa.id).concat("</td><td>")
                     .concat(festa.nome).concat("</td><td>")
                     .concat(festa.data).concat("</td><td>")
                     .concat(festa.valorDoIngresso).concat("</td><td>")
                     .concat(festa.totalDeConvidados || 0).concat("</td></tr>"))

            return row
        }, "");

        elTBody.innerHTML = tbody.concat("<tr><td></td><td></td><td></td><td></td><td></td></tr>")
        this.$elTotal.innerText = list.length
    },
    initEvents: function() {
        this.$elGrid.querySelectorAll("tbody .item").forEach(function(row) {
            row.addEventListener("click", function(e) {
                var id = e.target.parentElement.querySelector("td").innerText
                location = "edit.html?id=".concat(id)
            })
        })
    }
}