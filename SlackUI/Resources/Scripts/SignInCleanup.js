/*
 * Clean up unnecessary elements from 'Sign In' path based pages.
 */
(function (d) {

    d.querySelector(".header_nav").style.display = 'none';

    d.querySelector("#page_contents > .align_center:last-child").style.display = 'none';
    d.querySelector("#page_contents").style.paddingBottom = 0;

}(document));
