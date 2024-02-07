var inputElm = document.querySelector('input[name=users-list-tags]');

function tagTemplate(tagData) {
    return `
        <tag title="${tagData.email}"
                contenteditable='false'
                spellcheck='false'
                tabIndex="-1"
                class="tagify__tag ${tagData.class ? tagData.class : ""}"
                ${this.getAttributes(tagData)}>
            <x title='' class='tagify__tag__removeBtn' role='button' aria-label='remove tag'></x>
            <div>
                <div class='tagify__tag__avatar-wrap'>
                    <img onerror="this.style.visibility='hidden'" src="${tagData.avatar}">
                </div>
                <span class='tagify__tag-text'>${tagData.name}</span>
            </div>
        </tag>
    `
}

//Dropdown Önerisi Taslağı
function suggestionItemTemplate(tagData) {
    return `
        <div ${this.getAttributes(tagData)}
            class='tagify__dropdown__item ${tagData.class ? tagData.class : ""}'
            tabindex="0"
            role="option">
            ${tagData.avatar ? `
            <div class='tagify__dropdown__item__avatar-wrap'>
                <img onerror="this.style.visibility='hidden'" src="${tagData.avatar}">
            </div>` : ''
        }
            <strong>${tagData.name}</strong>
            <span>${tagData.description}</span>
        </div>
    `
}

// initialize Tagify on the above input node reference
var usrList = new Tagify(inputElm, {
    tagTextProp: 'name', // very important since a custom template is used with this property as text
    enforceWhitelist: true,
    skipInvalid: true, // do not remporarily add invalid tags
    dropdown: {
        closeOnSelect: false,
        enabled: 0,
        classname: 'users-list',
        searchKeys: ['name', 'value']
    },
    templates: {
        tag: tagTemplate,
        dropdownItem: suggestionItemTemplate
    },
    whitelist: [
        {
            "value": 1,
            "name": "SuperUser",
            "avatar": "/asset/image/role/crown_root.png",
            "description": ""
        },
        {
            "value": 2,
            "name": "Admin",
            "avatar": "/asset/image/role/crown.png",
            "description": ""
        },
        {
            "value": 3,
            "name": "Member",
            "avatar": "/asset/image/role/member.png",
            "description": ""
        },
    ]
})

usrList.on('dropdown:show dropdown:updated', onDropdownShow)
usrList.on('dropdown:select', onSelectSuggestion)

var addAllSuggestionsElm;

function onDropdownShow(e) {
    var dropdownContentElm = e.detail.tagify.DOM.dropdown.content;

    if (usrList.suggestedListItems.length > 1) {
        addAllSuggestionsElm = getAddAllSuggestionsElm();

        // insert "addAllSuggestionsElm" as the first element in the suggestions list
        dropdownContentElm.insertBefore(addAllSuggestionsElm, dropdownContentElm.firstChild)
    }
}

function onSelectSuggestion(e) {
    if (e.detail.elm == addAllSuggestionsElm)
        usrList.dropdown.selectAll();
}

// create a "add all" custom suggestion element every time the dropdown changes
function getAddAllSuggestionsElm() {
    // suggestions items should be based on "dropdownItem" template
    return usrList.parseTemplate('dropdownItem', [{
        class: "addAll",
        name: "Tümünü seç",
        description: usrList.whitelist.reduce(function (remainingSuggestions, item) {
            return usrList.isTagDuplicate(item.value) ? remainingSuggestions : remainingSuggestions + 1
        }, 0) + " Rol"
    }]
    )
}