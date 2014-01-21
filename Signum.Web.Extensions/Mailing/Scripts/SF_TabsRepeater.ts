﻿/// <reference path="../../../../Framework/Signum.Web/Signum/Headers/jquery/jquery.d.ts"/>
/// <reference path="../../../../Framework/Signum.Web/Signum/Scripts/references.ts"/>

module SF.TabsRepeater 
{
    function $control() {
        return $(".sf-tabs-repeater .sf-repeater-field");
    };

    function removeItem (elem) {
        var $elem = $(elem);
        var itemPrefix = elem.id.substring(0, elem.id.indexOf("_btnRemove"));
        $elem.closest('.sf-repeater-field').SFControl<SF.EntityRepeater>().remove(itemPrefix);
        var $li = $elem.closest('li');
        if ($li.hasClass("ui-tabs-selected")) {
            $control().tabs("select", 0);
        }
        $li.remove();
    };

    function getItemIndex (controlId, itemPrefix) {
        return parseInt(itemPrefix.substring(controlId.length + 1, itemPrefix.indexOf("btnRemove") - 1), 10);
    };

    export function addItem () {
        var $container = $control();
        var controlId = $container.attr("id");
        var repeater = $('#' + controlId).SFControl<SF.EntityRepeater>();

        var newPrefixIndex = 0;
        var $lastElement = $container.children("ul").find("li:last").find(".sf-remove");
        if ($lastElement.length > 0) {
            var lastRemoveId = $lastElement.attr("id");
            newPrefixIndex = getItemIndex(controlId, lastRemoveId) + 1;
        }
        var itemPrefix = SF.compose(controlId, newPrefixIndex.toString());

        var viewOptions = {
            containerDiv: "",
            prefix: itemPrefix,
            type: repeater.staticInfo().types()
        };

        var template = repeater.getEmbeddedTemplate();
        if (!SF.isEmpty(template)) {
            template = template.replace(new RegExp(SF.compose(controlId, "0"), "gi"), viewOptions.prefix);
            repeater.onItemCreated(template, viewOptions);
        }

        var $tabsContainer = $container.find(".ui-tabs-nav");
        var $newElement = $(".sf-repeater-element:last");
        var $newElementLegend = $newElement.find("legend");

        $("<li><a class='sf-tab-header' href='#" + $newElement.attr("id") + "'>[New]</a>" + $newElementLegend.html() + "</li>")
                    .appendTo($tabsContainer);

        $newElementLegend.remove();

        $container.tabs("refresh");
        $container.tabs("option", "active", $container.children("ul").find("li").length - 1);
    };

    once("SF.TabRepeater", ()=>{
        var $container = $control().prepend($("<ul></ul>"));
        $container.tabs();

        $container.find(".sf-repeater-element").each(function () {
            var $legend = $(this).children("legend");
            var title = $(this).find(".sf-tab-title").val();

            $("<li><a class='sf-tab-header' href='#" + this.id + "'>" + title + "</a>" + $legend.html() + "</li>")
                    .appendTo($container.find(".ui-tabs-nav"));

            $legend.remove();
        });

        $container.tabs("refresh");
        $container.tabs("option", "active", 0);

        $container.find("ul").on("click", "li .sf-remove", function (e) {
            e.preventDefault();
            removeItem(this);
        });
    });
}