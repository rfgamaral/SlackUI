/*
 * Clean up unnecessary elements from 'Sign In' path based pages.
 */
(function (d) {

    d.querySelector("header .header_nav").style.display = 'none';

    d.querySelector("#page").style.minHeight = 0;

    d.querySelector("#page_contents").style.paddingBottom = 0;
    d.querySelector("#page_contents > .align_center:last-child").style.display = 'none';

}(document));
