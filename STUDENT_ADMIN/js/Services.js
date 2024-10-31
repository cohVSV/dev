/**
 * @class Event listenres class
 * @constructor
 */
function DEventListeners(hostObj) {
	this._hostObj = hostObj;
	this._listeners = new Object();
}

DEventListeners.prototype = {

  add : function (event, handler) {
    event = event.toLowerCase();
    if (!this._listeners[event]) {
      this._listeners[event] = new Array();
    }
    var e = this._listeners[event];
    return e[e.length] = handler;
  },

  notify : function (event, args) {
  	event = event.toLowerCase();
    var _args = {sender : this._hostObj, args : args};
    var listeners = this._listeners[event];
    if (listeners) {
      for (var i = 0; i < listeners.length; i++) {
        listeners[i](_args);
      }
    }
    if ((!listeners || listeners.length == 0) && event == "onerror") {
    	alert(args);
    }
  }
};

DEventListeners.support = function (obj) {
  obj._listeners = new DEventListeners(obj);
  obj.addListener = function (event, handler) {
    obj._listeners.add(event, handler);
  };
};

/**
 * Classes provides control capability to render a list of items.
 * Features:
 *   Multicolumn
 *   Scrollable
 *   Autofit to data
 *   Design is controlled by the CSS
 *   Accessibility: supports font changing
 * The DList is supposed to be reused by another components.
 * Based on the Model-View-Controller pattern. DListModel 
 * stores information about DList state, 
 * DListController's methods modifies model, DListView 
 * renders the model.
 * 
 * The size of the list is controlled by the _size property.
 * When this proeprty is -1 then list will be resized to show
 * all items.
 * 
 * Reusing guide.
 * 
 * 1. Specify component's top and left offsets.
 * 2. Subscribe on component's events.
 * 3. Configure how events will be sent to DList.
 * 
 * Events:
 *   OnChangeSelected - called when the item in the 
 *     list is selected. args = index of selected element.
 *   OnChangeItems - called when the collection 
 *     of items is changed. When the event is called the 
 *     selected item is not changed yet. The item that will 
 *     be selected are available in the event args property.
 *   OnChangeVisibility - called when the vilible state 
 *     is changed.
 *   OnActivate - called when the item is activated. 
 *     It happens when user click mouse button on the combobox's list 
 *     or clicks enter in the textarea list.
 * @class DListModel
 * @constructor
 */
function DListModel() {
  this._items = new Array();
  this._selected = -1;
  this._controller = new DListController(this);
  this._visibility = DListModel.HIDDEN;
  this._size = 15;
  this._columns = new Array();
  this._enableOnMoveOut = true;

  DEventListeners.support(this);
}

DListModel.VISIBLE = true;
DListModel.HIDDEN = false;

DListModel.prototype = {

  setActive : function (index) {
    this._listeners.notify("OnActivate", index);
  },

  setSelected : function (index) {
    if (index != this._selected) {
      this._listeners.notify("OnChangeSelected", index);
      this._selected = index;
    }
  },

  getSelected : function () {
    return this._selected;
  },

  /**
   * When the collection of the items is updated, 
   * the _columns collection will be changed and 
   * the selection will be cleared.
   */
  setItems : function (items) {
    this.setSelected(-1);
    this._items = items;
    if (0 == items.length) {
      this._columns = new Array();
    } else {
      this._columns = this._getColumns(items[0]);
    }
    this._listeners.notify("OnChangeItems");
  },

  getColumns : function () {
    return this._columns;
  },

  isVisible : function () {
    return DListModel.VISIBLE == this._visibility;
  },

  setVisibility : function (value) {
    if (this._visibility != value) {
      this._visibility = value;
      this._listeners.notify("OnChangeVisibility");
    }
  },

  getController : function () {
    return this._controller;
  },

  /**
   * @private
   */
  _getColumns : function (row) {
    var columns = new Array();
    for (var column in row) {
      columns[columns.length] = column;
    }
    return columns;
  }

};

/**
 * Events:
 *   OnMoveOut - special controller event, which is called 
 *     when the user click UP key and the first element 
 *     in the list is selected. When this event is enabled,
 *     the event will be called instead of selecting 
 *     the last element.
 * @class
 * @constructor
 */
function DListController(model) {
  this._model = model;

  DEventListeners.support(this);
}

DListController.prototype = {

  show : function () {
    this._model.setVisibility(DListModel.VISIBLE);
  },

  hide : function () {
    this._model.setVisibility(DListModel.HIDDEN);
  },

  moveUp : function () {
    var selected = this._model.getSelected();
    this.unselect();
    with (this._model) {
      if (_enableOnMoveOut && 0 == selected) {
        this._listeners.notify("OnMoveOut");
      } else {
        this._move(selected - 1, _items.length - 1);
      }
    }
  },

  moveDown : function () {
    this._move(this._model.getSelected() + 1, 0);
  },

  movePageDown : function () {
    with (this._model) {
      this._move(getSelected() 
        + Math.ceil(((-1 == _size) ? _items.length : _size)/3), 
        _items.length - 1);
    }
  },

  movePageUp : function () {
    with (this._model) {
      this._move(getSelected() 
        - Math.ceil(((-1 == _size) ? _items.length : _size)/3), 0);
    }
  },

  /**
   * @private
   */
  _move : function (newIndex, ex) {
    this.unselect();
    with (this._model) {
      if (newIndex > -1 && newIndex < _items.length) {
        setSelected(newIndex);
      } else {
        setSelected(ex);
      }
    }
  },

  select : function (index) {
    this.unselect();
    this._model.setSelected(index);
  },

  unselect : function () {
    with (this._model) {
      if (-1 != _selected) {
        setSelected(-1);
      }
    }
  },

  /**
   * Method is called when the 
   */
  activate : function (index) {
    this._model.setActive(index);
  }

};

/**
 * Events:
 *   OnCreateDiv - called when the main div is created.
 *   OnAppendCell {node, name, value}
 *   OnAppendRow {node, data}
 *   OnCreateDiv div
 * @class
 * @constructor
 */
function DListView() {
  this._autofit = true;
  this._width = "100px";
  this._top = "0px";
  this._left = "0px";
  this._model = null;

  this._styles = {
    main : "border: 1px black solid; padding: 0px; position: absolute;"
      + "z-index: 20; white-space: nowrap;"
      + "font-family: arial, sans-serif; background-color: white;"
      + "color: black; overflow: auto; cursor: default;",
    parent : "",
    selected : "color: white; background-color: #3366CC;",
    row : "padding-left: 3; padding-right: 3;",
    columns : new Object()
  };

  this._div = null;

  DEventListeners.support(this);
}

DListView.prototype = {

  setModel : function (model) {
    this._model = model;

    var _this = this;
    with (model._listeners) {
      add("OnChangeItems", function (e) { _this._modelChangeItems(e); });
      add("OnChangeSelected", function (e) { _this._modelChangeSelected(e); });
      add("OnChangeVisibility", function (e) { _this._modelChangeVisibility(e); });
    }
  },

/* ============ MODEL'S EVENTS ============== */

  /**
   * @private
   */
  _modelChangeSelected : function (e) {
    if (-1 == e.args) {
      var div = this._div.childNodes[this._model.getSelected()];
      // restore the default style
      DHtmlHelper.applyStyle(div, this._styles.row + '; height:' + div.style.height);
      // restore style
      for (var node = div.firstChild.firstChild; node; node = node.nextSibling) {
        DHtmlHelper.applyStyle(node, node._cssText);
      }
    } else {
      var div = this._div.childNodes[e.args];
      // apply the selected style and preserve the height.
      DHtmlHelper.applyStyle(div, this._styles.row + this._styles.selected 
        + '; height:' + div.style.height);
      // save the current style
      for (var node = div.firstChild.firstChild; node; node = node.nextSibling) {
        node._cssText = DHtmlHelper.getStyle(node);
        node.style.color = div.style.color;
      }
      // scroll to selection
      var mDiv = this._div;
      var st = mDiv.scrollTop;
      var ot = div.offsetTop;
      if ((st - ot) > 0) {
        mDiv.scrollTop = ot;
      } else if ((st + mDiv.clientHeight - ot - div.offsetHeight) < 0) {
        mDiv.scrollTop = ot + div.offsetHeight - mDiv.clientHeight;
      }
    }
  },

  /**
   * @private
   */
  _modelChangeVisibility : function (e) {
    if (e.sender.isVisible()) {
      this._div.style.visibility = "visible";
      this._div.style.display = "block";
    } else {
      this._div.style.display = "none";
    }
  },

  /**
   * @private
   */
  _modelChangeItems : function () {
    if (this._div) {
      this._rebuild();
    }
  },

/* ============ POSITIONING ============== */

  setWidth : function (value) {
    this._width = value;
    this.resize();
  },

  setTop : function (value) {
    this._top = value;
    this.resize();
  },

  setLeft : function (value) {
    this._left = value;
    this.resize();
  },

/* ============ DRAWING ============== */

  draw : function () {
    div = document.createElement("DIV");
    DHtmlHelper.applyStyle(div, this._styles.main + this._styles.parent);
    div.style.visibility = "hidden";
    document.body.appendChild(div);
    this._div = div;
    var _this = this;
    var _eh = DHtmlHelper.addEventHandler;
    _eh(div, "mousedown", function () { _this._listeners.notify("OnDivMouseDown"); });
    _eh(div, "mouseup", function () { _this._listeners.notify("OnDivMouseUp"); });
    _eh(div, "focus", function () { _this._listeners.notify("OnDivFocus"); });
    this._listeners.notify("OnCreateDiv", div);
    this._rebuild();
  },

  /**
   * Structure of the html tree:
   * %begin html%
   * <!-- main div, this._div -->
   * <div>
   * <!-- open item's div -->
   * <div>
   * <!-- open cells' div -->
   * <div>
   * <!-- open cell's div -->           -> <!-- open cell's div -->
   * <div>                             ^   <div>
   * <!-- begin cell's style div -->   ^   <!-- begin cell's style div -->
   * <div>                             ^   <div>
   * <!-- cell's content span -->      ^   <!-- cell's content span -->
   * <span>cell's value</span>         ^   <span>cell's value</span>
   * </div>                            ^   </div>
   * <!-- end cell's style div -->     ^   <!-- end cell's style div -->
   * </div>                            ^   </div>
   * <!-- close cell's div -->       ->    <!-- close cell's div -->
   * </div>
   * <!-- close cells' div -->
   * </div>
   * <!-- close item's div -->
   * </div>
   * %end%
   * 
   * cell's inner span is used to calculate width of cell's content.
   * @private
   */
  _rebuild : function () {
    var div = this._div;
    this._div.style.visibility = "hidden";
    this._div.style.display = "block";
    // remove all child nodes
    while (div.lastChild) {
      div.removeChild(div.lastChild);
    }

    var rows = this._model._items;
    // hide list if there are no items
    if (0 == rows.length) {
      return this._model.getController().hide();
    }
    // rows.length > 0
    var columns = this._model.getColumns();
    var columnCount = columns.length;
    var _this = this
    for (var rowCnt = 0; rowCnt < rows.length; rowCnt++) {
      var row = rows[rowCnt];
      var itemDiv = div.appendChild(document.createElement("DIV"));
      itemDiv._row = rowCnt;
      DHtmlHelper.applyStyle(itemDiv, this._styles.row);
      itemDiv.onmousedown = function () { _this._itemMouseClick(this._row); };
      itemDiv.onmouseover = function () { _this._itemMouseOver(this._row); };
      var cellsDiv = itemDiv.appendChild(document.createElement("DIV"));
      cellsDiv.style.overflow = "hidden";
      for (var column in row) {
        var cellContentDiv = cellsDiv.appendChild(document.createElement("DIV"));
        var columnStyle = this._styles.columns[column];
        if (columnStyle) {
          DHtmlHelper.applyStyle(cellContentDiv, columnStyle);
        }
        with (cellContentDiv) {
          if ("" == style.width) {
            style.width = Math.ceil(100 / columnCount) + "%";
          }
          style.styleFloat = "left";
          style.cssFloat = "left";
          style.overflow = "hidden";
        }
        var innerSpan = cellContentDiv.appendChild(document.createElement("SPAN"));
        innerSpan.appendChild(document.createTextNode(row[column]));
        this._listeners.notify("OnAppendCell", 
          {node : cellContentDiv, name : column, value: row[column]});
      }
      cellsDiv.lastChild.style.cssFloat = "right";
      this._listeners.notify("OnAppendRow", {node: itemDiv, data: row});
    }
    this.resize();
    this._div.style.display = "none";
    this._div.style.visibility = "visible";
    if (this._model.isVisible()) {
      this._div.style.display = "block";
    }
  },

/* ============ MAIN DIV'S EVENTS ============== */

  /**
   * @private
   */
  _itemMouseOver : function (index) {
    this._model.getController().select(index);
  },

  /**
   * @private
   */
  _itemMouseClick : function (index) {
    this._model.getController().activate(index);
  },

  resize : function () {
    with (this) {
      if (!_div) { return; }

      _div.style.width = _width;
      _div.style.top = _top;
      _div.style.left = _left;

      // tune height
      var height = _getMaxHeight();
      for(var row = _div.firstChild; row; row = row.nextSibling) {
        row.style.height = height + 'px';
      }
      if (-1 != _model._size) {
        var maxHeight = height * Math.min(_model._size, _model._items.length) + 2;
        _div.offsetHeight;
        if (DHtmlHelper._isGecko) {
          maxHeight -= 2;
        }
        _div.style.height = maxHeight + "px";
      }

      // tune width
      if (_autofit) {
        var width = _div.offsetWidth - (DHtmlHelper._isGecko ? 2 : 0);
        while (_needIncreaseWidth() && width < 800) {
          width += 10;
          _div.style.width = width + "px";
        }
        // MSIE FIX
        var maxWidth = width + 30;
        while (this._div.clientWidth < this._div.scrollWidth && width < maxWidth) {
          width++;
          _div.style.width = width + "px";
        }
      }
    }
  },

  /**
   * @private
   */
  _needIncreaseWidth : function () {
    return this._walkOverItems(function (cell) {
      return cell.offsetWidth < cell.firstChild.offsetWidth;
    });
  },

  /**
   * @private
   */
  _getMaxHeight : function () {
    var height = 0;
    this._walkOverItems(function (cell) {
      var newHeight = cell.offsetHeight;
      height = (newHeight > height) ? newHeight : height;
    });
    return height;
  },

  /**
   * @private
   */
  _walkOverItems : function (callback) {
    for(var row = this._div.firstChild; row; row = row.nextSibling) {
      for (var column = row.firstChild.firstChild; column; column = column.nextSibling) {
        if (callback(column)) {
          return true;
        }
      }
    }
    return false;
  }

};

/**
 * @class
 * @constructor
 */
function DHtmlHelper() {}

DHtmlHelper._isGecko = false;
DHtmlHelper._isOpera = false;
if (navigator && navigator.userAgent) {
  DHtmlHelper._isGecko = (-1 != navigator.userAgent.indexOf('Gecko'));
  DHtmlHelper._isOpera = (-1 != navigator.userAgent.indexOf('Opera'));
}

DHtmlHelper.applyStyle = function (obj, style) {
  obj.setAttribute('style', style);
  obj.style.cssText = style;
};

DHtmlHelper.getStyle = function (obj) {
  if (DHtmlHelper._isGecko) {
    return obj.getAttribute('style');
  }
  return obj.style.cssText;
};

DHtmlHelper.getPropertyRec = function (obj, property) {
  var value = 0;
  while (obj) {
    value += obj[property];
    obj = obj.offsetParent;
  }
  return value;
};

DHtmlHelper.getAbsTop = function (obj) {
  return DHtmlHelper.getPropertyRec(obj, "offsetTop");
};

DHtmlHelper.getAbsLeft = function (obj) {
  return DHtmlHelper.getPropertyRec(obj, "offsetLeft");
};

DHtmlHelper.addEventHandler = function (element, event, handler) {
	if (element) {
		if (element.addEventListener) {
			element.addEventListener(event, handler, false);
		} else {
			var oldHandler = (element['on'+event]) ? element['on'+event] : function () {};
			element['on'+event] = function () {
				oldHandler.apply(element, arguments);
				handler.apply(element, arguments)
			};
		}
	}
};

DHtmlHelper.getRowNumber = function(control) {
	
	var idValue = control.id.substring(substrcontrolId.lastIndexOf("_") + 1);
	return idValue.valueOf();
};

/**
 * This class contains the constants for 
 * the keycodes that are used in the autocomplete classes.
 * @class
 * @constructor
 */
function DKeyCodes() {}

/**
 * @final
 */
DKeyCodes.KEY_BACKSPACE = 8;

/**
 * @final
 */
DKeyCodes.KEY_DELETE = 46;

/**
 * @final
 */
DKeyCodes.KEY_UP = 38;

/**
 * @final
 */
DKeyCodes.KEY_DOWN = 40;

/**
 * @final
 */
DKeyCodes.KEY_LEFT = 37;

/**
 * @final
 */
DKeyCodes.KEY_RIGHT = 39;

/**
 * @final
 */
DKeyCodes.KEY_ENTER = 13;

/**
 * @final
 */
DKeyCodes.KEY_PAGEUP = 33;

/**
 * @final
 */
DKeyCodes.KEY_PAGEDOWN = 34;

/**
 * @final
 */
DKeyCodes.KEY_SHIFT = 16;

/**
 * @final
 */
DKeyCodes.KEY_HOME = 36;

/**
 * @final
 */
DKeyCodes.KEY_END = 35;

/**
 * @final
 */
DKeyCodes.KEY_SHIFT = 16;

/**
 * @final
 */
DKeyCodes.KEY_TAB = 9;

/**
 * @final
 */
DKeyCodes.KEY_ALT = 18;

/**
 * @final
 */
DKeyCodes.KEY_ESCAPE = 27;

/**
 * Control with autocomplete and list.
 * 
 * Control's value is a combination of two parts: 
 *   typed control value and completed control value.
 * Example:
 *   Alex[ander] -- completed value = Alexander, typed value = Alex.
 * Value Column is a column, which values will be searched for.
 * controlOnMoveOutValue will be set when the OnMoveOut event occurs.
 * Events:
 *   OnChangeControlTypedValue - called when the typed part of 
 *     the value is set.
 *   OnChangeControlCompletedValue
 *   OnChangeValues
 *   OnChangeControlOnMoveOutValue
 */
function DListControlModel() {}

DListControlModel.prototype = {

  _construct : function () {
    this._list = new DListModel();
    this._valueColumn = "";
    this._controlOnMoveOutValue = "";
    this._controlTypedValue = "";
    this._controlCompletedValue = "";
    this._items = new Array();
    this._columns = new Array();
    this._controller = null;
    DEventListeners.support(this);
  },

  getController : function () {
    return this._controller;
  },

  getItem : function (index) {
    return this._items[index];
  },

  getValueColumn : function () {
    return this._valueColumn;
  },

  setControlTypedValue : function (value) {
    this._controlTypedValue = value;
    this._listeners.notify("OnChangeControlTypedValue");
  },

  getControlTypedValue : function () {
    return this._controlTypedValue;
  },

  setControlCompletedValue : function (value) {
    this._controlCompletedValue = value;
    this._listeners.notify("OnChangeControlCompletedValue");
  },

  getControlCompletedValue : function () {
    return this._controlCompletedValue;
  },

  setValues : function (typed, completed) {
    this.setControlTypedValue(typed);
    this.setControlCompletedValue(completed);
    this._listeners.notify("OnChangeValues");
  },

  setControlOnMoveOutValue : function (value) {
    this._controlOnMoveOutValue = value;
    this._listeners.notify("OnChangeControlOnMoveOutValue");
  },

  /**
   * Search for item matches criteria. Returns -1 if the item is not found. 
   * Returns item's index when the item is found.
   */
  searchItem : function (key, compare) {
    key = key.toUpperCase();
    var items = this._items;
    for (var i = 0; i < items.length; i++) {
      if (compare(key, items[i][this._valueColumn])) {
        return i;
      }
    }
    return -1;
  }

};


/**
 * @constructor
 */
function DListControlController() {
}

DListControlController.prototype = {

  _construct : function () {
    this._model = null;
  },

  setModel : function (model) {
    this._model = model;
    var _this = this;
    model._list.addListener("OnActivate", function (e) {
      _this.activate(e.args);
    });
    model._list.getController().addListener(
      "OnMoveOut", function (e) {
        _this._model.setControlTypedValue(_this._model._controlOnMoveOutValue);
      }
    );
  },

  /**
   * Moves list's selection.
   * Called when user clicks navigation button (UP/DOWN/PAGEUP/PAGEDOWN).
   * direction
   * -2 - PAGE UP
   * -1 - UP
   * 1 - DOWN
   * 2 - PAGE DOWN
   */
  moveSelection : function (direction) {
    with (this._model._list.getController()) {
      switch (direction) {
      case -2:
        movePageUp(); break;
      case -1:
        moveUp(); break;
      case 1:
        moveDown(); break;
      case 2:
        movePageDown(); break;
      }
    }
    with (this._model) {
      var selected = _list.getSelected();
      if (-1 != selected) {
        this.setValueFromItem(getItem(selected));
      }
    }
  },

  unselectListItem : function () {
    this._model._list.getController().unselect();
  },

  hideList : function () {
    this._model._list.getController().hide();
  },

  /**
   * Sets the control's value, bound control's value, and hides the list 
   * of items.
   */
  activate : function (item) {
    with (this) {
      setValueFromItem(_model.getItem(item));
      hideList();
    }
  },

  /**
   * Sets the control's value, bound control's value.
   * Called when user navigate on list's item using keyboard.
   */
  select : function (index) {
    with (this) {
      setValueFromItem(_model.getItem(index));
      _model._list.setSelected(index);
    }
  },

  /**
   * @private
   */
  _selectItemInList : function (value, compare) {
    this._model._list.setSelected(-1);
    var index = this._model.searchItem(value.toUpperCase(), compare);
    if (-1 != index) {
      this._model._list.getController().select(index);
      with (this._model) {
        var item = getItem(index);
        this.setValueFromItem(item);
        var itemValue = item[getValueColumn()];
        var typedValue = itemValue.substr(0, value.length);
        setValues(value, itemValue);
        this._model.setControlOnMoveOutValue(value);
      }
    } else {
      this._model.setControlOnMoveOutValue(value);
    }
  }

};


/**
 * @constructor
 */
function DListControlView() {
}

DListControlView.prototype = {

  _construct : function () {
    __reg(this, this._class);
    this._valueControl = null;
    this._valueControlHasFocus = false;
    this._refocus = false;

    this._list = new DListView();
    this._model = null;
  },

  setModel : function (model) {
    this._model = model;
    var _this = this;
    with (this._list) {
      setModel(model._list);
      addListener("OnDivMouseDown", function () {
        _this._refocus = true;
      });

      addListener("OnDivFocus", function () {
        _this._valueControl.focus();
      });

      addListener("OnDivMouseUp", function () {
        _this._valueControl.focus();
      });
    }
    this._model.addListener("OnChangeControlTypedValue", function() {
      _this._modelChangeControlTypedValue();
    });
    this._model.addListener("OnChangeValues", function() {
      _this._modelChangeValues();
    });
  },

  /**
   * @private
   */
  _configureControl : function (control) {
    control.autocomplete = "off";
    control.setAttribute("autocomplete", "off");
    var edf = DHtmlHelper.addEventHandler;
    var _this = this;
    edf(control, "keyup", function (e) {
      e = e ? e : window.event;
      _this._controlKeyUp(e);
    });
    edf(control, "blur", function (e) {
      e = e ? e : window.event;
      _this._controlBlur(e);
    });
    edf(control, "focus", function (e) {
      e = e ? e : window.event;
      _this._valueControlHasFocus = true;
    });
    this._valueControl = control;
  },

  /**
   * @private
   */
  _controlBlur : function (e) {
    setTimeout(this._className + ".registry[" + this._key +"]._delayedControlBlur();", 50);
  },

  /**
   * @private
   */
  _delayedControlBlur : function () {
    this._valueControlHasFocus = false;
    if (this._refocus) {
      this._refocus = false;
    } else {
      this._model.getController().hideList();
    }
  },

  /**
   * @private
   */
  _convertKey2Dir : function (key) {
    with (DKeyCodes) {
      if (KEY_PAGEUP == key) {
        return -2;
      }
      if (KEY_UP == key) {
        return -1;
      }
      if (KEY_DOWN == key) {
        return 1;
      }
      if (KEY_PAGEDOWN == key) {
        return 2;
      }
    }
    return 0;
  },

  /**
   * @private
   */
  _modelChangeControlTypedValue : function () {
    var _value = this._model.getControlTypedValue();
    with (this._valueControl) {
      if (value != _value) {
        value = _value;
      }
    }
    this._valueControl.value = this._model.getControlTypedValue();
  },

  /**
   * @private
   */
  _modelChangeValues : function () {
    var typed = this._model.getControlTypedValue();
    var completed = this._model.getControlCompletedValue();
    if (this._valueControl.value == this._model.getControlTypedValue()) {
      this._valueControl.value = completed;
      var length = typed.length;
      var c = this._valueControl;
      if (c.createTextRange) {
        var u = c.createTextRange();
        u.moveStart("character", length);
        u.select();
      } else if (c.setSelectionRange) {
        c.setSelectionRange(length, completed.length)
      }
    }
  },

  /**
   * @private
   */
  getSelectionLength : function (control) {
    if (control.createTextRange) {
      return document.selection.createRange().duplicate().text.length;
    }
    if (control.setSelectionRange) {
      return control.selectionEnd - control.selectionStart
    }
    return -1;
  }

};

function DFilterType() {}
DFilterType.SEARCH = "s";
DFilterType.STARTS_WIDTH = "w";

function DAcMode() {}
DAcMode.AUTOCOMPLETE = "a";
DAcMode.SEARCH = "s";

function DEnterMode() {}
DEnterMode.SELECTS = "s";
DEnterMode.SUBMITS = "m";

/**
 * @constructor
 */
function DAutocompleteModel() {
  this._construct();
  this._controller = new DAutocompleteController(this);
  this._itemsKey = "";
  this._dataSource = null;
  this._mode = DAcMode.AUTOCOMPLETE;
  this._enterMode = DEnterMode.SELECTS;
}

DAutocompleteModel.prototype = new DListControlModel();

DAutocompleteModel.prototype.setItems = function (items) {
  if (items.length > 0) {
    this._columns = this._list._getColumns(items[0]);
  }
  this._items = items;
  if (!this._valueColumn) {
    this._valueColumn = this._columns[0];
  }
  this._list.setItems(items);
  this._listeners.notify("OnChangeItems");
};

DAutocompleteModel.prototype.setMode = function (mode) {
  this._mode = mode;
};

DAutocompleteModel.prototype.getMode = function () {
  return this._mode;
};


DAutocompleteModel.prototype.setDataSource = function (dataSource) {
  this._dataSource = dataSource;
  var _this = this;
  this._dataSource.addListener('OnDataRequestComplete', function (e) {
    _this._itemsKey = e.args.key;
    _this.setItems(e.args.data);
  });
};

DAutocompleteModel.prototype.getDataSource = function () {
  return this._dataSource;
};

DAutocompleteModel.prototype.clearList = function () {
  this.setItems(new Array());
};

function DAutocompleteController(model) {
  this._construct();
  this.setModel(model);
}

DAutocompleteController.prototype = new DListControlController();

DAutocompleteController.prototype.setValueFromItem = function (item) {
  with (this._model) {
    setControlTypedValue(item[getValueColumn()]);
  }
};

DAutocompleteController.prototype.changeValue = function (value, findMatch) {
  if ("" == value) {
    this.hideList()
    this._model.clearList();
  } else {
    this._model.setControlTypedValue(value);
    this._model.getDataSource().request(value);
    if (findMatch && DAcMode.AUTOCOMPLETE == this._model._mode) {
      this._model.setControlCompletedValue(value);
      this._selectItemInList(value, function (key, value) { 
        return key == value.toUpperCase().substr(0, key.length);
      });
    }
  }
};

/**
 * @constructor
 */
function DAutocompleteView(model) {
  this._construct();
  this.setModel(model);

  this._className = "DAutocompleteView";
  var _this = this;
  this._model._list.addListener("OnChangeItems", function() {
    with (_this) {
      _modelChangeItems();
      if (_highlighter) {
        _highlighter.highlight(_list, _model._itemsKey);
      }
    }
  });

  this._model.addListener("OnChangeItems", function() {
    with (_this._model) {
      if (DAcMode.AUTOCOMPLETE == _mode 
        && (_this._valueControl.value == getControlCompletedValue())) {
        getController()._selectItemInList(getControlTypedValue().toUpperCase(),
          function (key, value) {
            return key == value.toUpperCase().substr(0, key.length);
          });
      }
    }
  });

  this._highlighter = null;
}

DAutocompleteView.prototype = new DListControlView();
DAutocompleteView.prototype._class = DAutocompleteView;


DAutocompleteView.prototype._modelChangeItems = function () {
  with (this._model) {
    if (_items.length > 0) {
      _list.getController().show();
    }
  }
};

DAutocompleteView.prototype.setControl = function (control) {
  this._configureControl(control);
  var _this = this;
  control.onkeypress = function (e) {
    e = e ? e : window.event;
    return !_this._model._list.isVisible() || _this._model._enterMode == DEnterMode.SUBMITS || e.keyCode != DKeyCodes.KEY_ENTER;
  };
};


DAutocompleteView.prototype._controlKeyUp = function (e) {
  with (this._model.getController()) {
    if (this._model._list.isVisible()) {
      var direction = this._convertKey2Dir(e.keyCode);
      if (0 != direction) {
        moveSelection(direction);
        return;
      }
    }
    switch (e.keyCode)
    {
    case DKeyCodes.KEY_ALT:
    case DKeyCodes.KEY_END:
    case DKeyCodes.KEY_HOME:
    case DKeyCodes.KEY_LEFT:
    case DKeyCodes.KEY_RIGHT:
    case DKeyCodes.KEY_SHIFT:
      unselectListItem();
      break;
    case DKeyCodes.KEY_BACKSPACE:
    case DKeyCodes.KEY_DELETE:
      unselectListItem();
      changeValue(this._valueControl.value, false);
      break;
    case DKeyCodes.KEY_TAB:
      break;
    case DKeyCodes.KEY_ENTER:
      hideList();
      break;
    default:
      if (this.getSelectionLength(this._valueControl) == 0) {
        changeValue(this._valueControl.value, true);
      }
    }
    if ("" == this._valueControl.value) {
      hideList();
    }
  }
};

DAutocompleteView.prototype.setHighlighter = function (highlighter) {
  this._highlighter = highlighter;
};

DAutocompleteView.prototype.draw = function () {
  with (this) {
    _list.setWidth(_valueControl.offsetWidth);
    _list.setTop(DHtmlHelper.getAbsTop(_valueControl) + _valueControl.offsetHeight);
    _list.setLeft(DHtmlHelper.getAbsLeft(_valueControl));
    _list.draw();
  }
};

/**
 * @constructor
 */
function DListBasicHighlighter() {}

DListBasicHighlighter.prototype = {

  highlight : function (listView, key) {
    key = key.toUpperCase();
    var div = listView._div;
    for (var itemDiv = div.firstChild; itemDiv; itemDiv = itemDiv.nextSibling) {
      for (var cellDiv = itemDiv.firstChild.firstChild; cellDiv; cellDiv = cellDiv.nextSibling) {
        var newSpan = document.createElement("SPAN");
        var text = cellDiv.firstChild.firstChild.nodeValue;
        var uText = text.toUpperCase();
        var begin = uText.indexOf(key);
        if (-1 != begin) {
          var prevBegin = 0;
          while (-1 != begin) {
            newSpan.appendChild(document.createTextNode(text.substring(prevBegin, begin)));
            prevBegin = begin + key.length;
            var b = document.createElement("strong");
            b.appendChild(document.createTextNode(text.substring(begin, prevBegin)));
            newSpan.appendChild(b);
            begin = uText.indexOf(key, begin + 1);
          }
          newSpan.appendChild(document.createTextNode(text.substr(prevBegin)));
        } else {
          newSpan.appendChild(document.createTextNode(text));
        }
        cellDiv.removeChild(cellDiv.firstChild);
        cellDiv.appendChild(newSpan);
      }
    }
    if (null != div.firstChild) {
      listView.resize();
    }
  }
};

/**
 * Updates the autocomplete using the local list. The data given to updater should be propertly sorted.
 */
function DLocalDataSource(items, filterType) {
  if (!filterType) {
    filterType = DFilterType.STARTS_WIDTH;
  }

  this._key = DLocalDataSource.registry.length;
  DLocalDataSource.registry[this._key] = this;

  this._items = items;
  this._columns = new Array();
  this._searchColumns = new Object();
  this._valueColumn = "";
  with (this) {
    if (_items.length > 0) {
      for (var column in _items[0]) {
        _columns[_columns.length] = column;
        _searchColumns[column] = true;
      }
      _valueColumn = _columns[0];
    }
  }

  this._timeout = 200;

  this._filterType = filterType;
  switch (this._filterType) {
  case DFilterType.SEARCH:
    this._check = this._checkSearch; break;
  case DFilterType.STARTS_WIDTH:
    this._check = this._checkStartsWith; break;
  }
  this._requestKey = "";

  DEventListeners.support(this);

  setInterval("DLocalDataSource.registry[" + this._key + "]._checkQueue();", this._timeout);
}

DLocalDataSource.registry = new Array();

DLocalDataSource.prototype = {

  _checkQueue : function () {
    if ("" != this._requestKey) {
      var result = new Array();
      var ukey = this._requestKey.toUpperCase();
      var items = this._items;
      for (var itemCnt in items) {
        if (this._check(items[itemCnt], ukey)) {
          result[result.length] = items[itemCnt];
        }
      }
      var key = this._requestKey;
      this._requestKey = "";
      this._listeners.notify("OnDataRequestComplete",
        {data : result, key : key});
    }
  },

  _checkSearch : function (data, key) {
    for (var column in data) {
      if (this._searchColumns[column] && -1 != data[column].toUpperCase().indexOf(key)) {
        return true;
      }
    }
    return false;
  },

  _checkStartsWith : function (data, key) {
    return (key == data[this._valueColumn].toUpperCase().substr(0, key.length));
  },

  request : function (key) {
    this._requestKey = key;
  }

}


/**
 * @constructor
 */
function DAjaxDataSource(url) {
  this._key = DAjaxDataSource.registry.length;
  DAjaxDataSource.registry[this._key] = this;

  this._url = url;
  this._keyword = "keyword";
  this._http = null;
  this._requestParams = new Array();
  this._data = null;

  this._cache = new Object();
  this._requestKey = "";

  DEventListeners.support(this);

  setInterval("DAjaxDataSource.registry[" + this._key + "]._checkQueue();", 200);
}

DAjaxDataSource.registry = new Array();

DAjaxDataSource.prototype = {

  /**
   * @private
   */
  _checkQueue : function () {
  	if ("" != this._requestKey) {
      if (this._cache[this._requestKey]) {
        this._listeners.notify("OnDataRequestComplete", 
          {data : this._cache[this._requestKey], key : this._requestKey});
      } else {
        if (!this._http) {
          var _this = this;
          this._http = new DHttpRequest();
          this._http.setData(this._data);
          this._http.addListener("OnDataAvailable", function (e) {
            _this._dataRequestComplete(e);
          });
        }
        with (this._http) {
          setUrl(this._url);
          for (par in this._requestParams) {
            setParameter(par, this._requestParams[par]);
          }
          send();
        }
      }
      this._requestKey = "";
    }
  },

  /**
   * @private
   */
  _dataRequestComplete : function (e) {
    var key = this._http._requestKey;
    //var key = this._requestKey;
    var items = e.args;
    this._cache[key] = items;
    this._listeners.notify("OnDataRequestComplete", {data : items, key : key});
    this._listeners.notify("onsuccess", items);
  },
  
  setData : function (data) {
  	this._data = data;  	
  },

  request : function (params) {
    if (typeof(params) == "object" && params.constructor == Array) {
      this._requestParams = params;
      for (par in params) {
        this._requestKey += par + params[par];
      }
    } else {
      this._requestParams[this._keyword] = this._requestKey = params;
    }
  }

};

DSerializer.JSON = 1;
DSerializer.JAVASCRIPT = 2;
DSerializer.WDDX = 3;

/**
 * @constructor
 */
function DSerializer(format) {
	this._format = format;
}


DSerializer.prototype = {

	/**
	 * @param string
	 * @return mixed
	 */
	unserialize : function(text) {
		switch (this._format) {
			case DSerializer.JAVASCRIPT:
				return this._unserializeJs(text);
			default:
				return this._unserializeJson(text);
		}
	},
	
	/**
	 * @param mixed
	 * @return string
	 */
	serialize : function(data) {
		switch (this._format) {
			case DSerializer.JAVASCRIPT:
				return this._serializeJs(data);
			default:
				return this._serializeJson(data);
		}
	},

	/**
	 * @private
	 * @param string
	 * @return mixed
	 */
	_unserializeJson : function(text) {
		return JSON.parse(text);
	},

	/**
	 * @private
	 * @param string
	 * @return mixed
	 */
	_unserializeJs : function(text) {
		text = text.replace(
			new RegExp("^<script>window\\.frameElement\\._http\\._setData\\("), "").replace(
			new RegExp("\\);</script>[ \\t\\n\\r]*$"), "") + "";
		return this._unserializeJson(text);
	},
	
	/**
	 * @private
	 * @param mixed
	 * @return string
	 */
	_serializeJson : function(data) {
		return JSON.stringify(data);
	},
	
	/**
	 * @private
	 * @param mixed
	 * @return string
	 */
	_serializeJs : function(data) {
		return "<script>window.frameElement._http._setData(" + this._serializeJson(data) + ");</script>";
	}
};

// JSON serializer/unserializer
var JSON=function(){var m={'\b':'\\b','\t':'\\t','\n':'\\n','\f':'\\f','\r':'\\r','"':'\\"','\\':'\\\\'},s={'boolean':function(x){return String(x);},number:function(x){return isFinite(x)?String(x):'null';},string:function(x){if(/["\\\x00-\x1f]/.test(x)){x=x.replace(/([\x00-\x1f\\"])/g,function(a,b){var c=m[b];if(c){return c;}
c=b.charCodeAt();return'\\u00'+
Math.floor(c/16).toString(16)+
(c%16).toString(16);});}
return'"'+x+'"';},object:function(x){if(x){var a=[],b,f,i,l,v;if(x instanceof Array){a[0]='[';l=x.length;for(i=0;i<l;i+=1){v=x[i];f=s[typeof v];if(f){v=f(v);if(typeof v=='string'){if(b){a[a.length]=',';}
a[a.length]=v;b=true;}}}
a[a.length]=']';}else if(typeof x.hasOwnProperty==='function'){a[0]='{';for(i in x){if(x.hasOwnProperty(i)){v=x[i];f=s[typeof v];if(f){v=f(v);if(typeof v=='string'){if(b){a[a.length]=',';}
a.push(s.string(i),':',v);b=true;}}}}
a[a.length]='}';}else{return;}
return a.join('');}
return'null';}};return{copyright:'(c)2005 JSON.org',license:'http://www.JSON.org/license.html',stringify:function(v){var f=s[typeof v];if(f){v=f(v);if(typeof v=='string'){return v;}}
return null;},parse:function(text){try{return!(/[^,:{}\[\]0-9.\-+Eaeflnr-u \n\r\t]/.test(text.replace(/"(\\.|[^"\\])*"/g,'')))&&eval('('+text+')');}catch(e){return false;}}};}();

function __reg(_obj, _class) {
  if (!_class.registry) {
    _class.registry = new Array();
  }
  _obj._key = _class.registry.length;
  _class.registry[_obj._key] = _obj;
}

/**
 * Author: Alexander Netkachev
 * License: TODO?
 * 
 * Provides support for communicating with HTTP servers.
 * HttpRequest class uses browser-specific 
 * method when it sends a request and 
 * recieves the answer. The class uses MSXML2.XMLHTTP/Microsoft.XMLHTTP ActiveX 
 * or XMLHttpRequest (Firefox/Mozilla/Opera 8.5) class for communication. 
 * When the browser does not support either of ActiveX or XMLHttpRequest, the 
 * IFRAME method would be used for the communication. MSIE ActiveX support may 
 * be disabled in the browser's settings, so that causes IFRAME method being used.
 * Class supports only GET request method.
 * 
 * Two events may be used to track the state of 
 * sent request. OnDataAvailable event is called 
 * when the server answer is recieved successfully. 
 * The OnReadyStateChange event is called when the
 * state of the internal XmlHttp object is changed.
 * 
 * Server should return the data in the following form:
 * <script>window.frameElement._http._setData(data);</script>
 * data may be array, string or object.
 * 
 * When the IFRAME transfer is used, the browser executes 
 * the script in the answer.
 * When the component transfer is used the
 * data is extracted from the text by removing text that 
 * before and including _setData( and text by regexp.
 * Then the data is passed to the eval function and the result is send to the event handlers.
 * To send the request the program should perform the following:
 *   Create the instance of the HttpRequest.
 *   Set the URL using the setUrl method.
 *   Optionally set the parameters of the URL using the setParam method.
 *   Bind the event handler function on the onDataAvailable event.
 *   Call the send method.
 * 
 * Example:
 *   var request = new HttpRequest();
 *   request.setUrl("/search.asp");
 *   request.setParam("keyword", "alex");
 *   request.addListener("OnDataAvailable", function (e) {
 *     alert("Server returns: " + e.args);
 *   });
 *   request.send();
 * 
 * Example code sends the request to the search.asp page 
 * with the parameter keyword=alex in the root of the web-server.
 * When the server returns the data the message box with the server 
 * response would be shown.
 * 
 * The class does nothing to check if it can be run in the particular 
 * browser.
 * The class does nothing with the encoding and the proper 
 * encoding should be set by the server using the content-type header.
 * 
 * Component and IFrame transfers was tested in the 
 * MSIE 6.0, Mozilla Firefox 1.0.7, Opera 8.5.
 * To test the class with other browsers the XmlHttpTest.html 
 * should be called. The test is passed when the log area contains the
 * "test" text.
 * 
 * See also:
 * http://google.com/search?q=XMLHttpRequest
 * http://google.com/search?q=XMLHTTP+site%3Amicrosoft.com
 */
function DHttpRequest() {
	__reg(this, DHttpRequest);
	this._key = DHttpRequest.registry.length;
	DHttpRequest.registry[this._key] = this;

	this._mode = DHttpRequest.XMLHTTP_MODE;
	this._requestMethod = DHttpRequest.GET_REQUEST;
	this._request = this.getXmlHttpRequest();
	if (null == this._request) {
		this._mode = DHttpRequest.IFRAME_MODE;
		this._request = this._createIFrame();
	}
	this._data = null;
	this._params = new Object();
	this._postParams = new Array();
	this._readyState = DHttpRequest.UNINITIALIZED;
	this._dataType = DSerializer.JSON;

	this._timeout = 1000;
	this._requestKey = 0;

	DEventListeners.support(this);
}

/**
 * Static class variable that is used to calculate 
 * the unique HttpRequest id.
 */
DHttpRequest.counter = 0;

/**
 * Values of the readyState property.
 * See also: http://msdn.microsoft.com/library/default.asp?url=/library/en-us/xmlsdk/html/0e6a34e4-f90c-489d-acff-cb44242fafc6.asp
 */
DHttpRequest.UNINITIALIZED = 0;
DHttpRequest.LOADING = 1;
DHttpRequest.LOADED = 2;
DHttpRequest.INTERACTIVE = 3;
DHttpRequest.COMPLETED = 4;

/* Modes of the HttpRequest transfer. */
DHttpRequest.XMLHTTP_MODE = 0;
DHttpRequest.IFRAME_MODE = 1;

/* Modes of the request */
DHttpRequest.POST_REQUEST = "POST";
DHttpRequest.GET_REQUEST = "GET";

DHttpRequest.prototype = {

	/**
	 * @private
	 */
	_abort : function (key) {
		if (this._requestKey == key) {
			this._request.abort();
		}
	},

	/**
	 * @private
	 */
	_createIFrame : function () {
		var frame = document.createElement("IFRAME");
		frame.style.width = frame.style.height = "0px";
		frame.style.display = "none";
		frame._http = this;
		document.body.appendChild(frame);
		return frame;
	},

	/**
	 * The current state of the request.
	 * @return integer
	 */
	getReadyState : function () {
		return this._readyState;
	},

	/**
	 * Creates the XmlHttp object for the current platform.
	 * @return Object
	 * The object for AJAX communication 
	 * or null when the object cannot be created.
	 */
	getXmlHttpRequest : function () {
		if (window.XMLHttpRequest) {
			return new XMLHttpRequest();
		}
		try { return new ActiveXObject("Msxml2.XMLHTTP"); } catch (e) {}
		try { return new ActiveXObject("Microsoft.XMLHTTP"); } catch (e) {}
		return null;
	},

	/**
	 * Sets reuest method.
	 */
	setRequestMethod : function (method) {
		this._requestMethod = method;
	},

  
	/**
	 * Sets the parameter of the request URL.
	 */
	setParameter : function (name, value) {
		if (typeof(value) == "object" && value.constructor == Array) {
			this._params[name] = value;
		} else {
			this._params[name] = value.toString();
		}
	},

	/**
	 * Sets the parameters of the request URL.
	 */
	setParameters : function (arr) {
		this._params = arr;
	},

	/**
	 * Sets the parameter for POST request.
	 */
	setPostParameter : function (name, value) {
		this._postParams[name] = value.toString();
	},

	/**
	 * Sets the POST parameters array.
	 *
	 */
	setPostParameters : function (arr) {
		this._postParams = arr;
	},
  
	/**
	 * Sets data for the request.
	 */
	setData : function (data) {
		this._data = data;
	},

	/**
	 * Sets the URL to which the request will be sent.
	 * @return string
	 * The string that is passed into the method.</returns>
	 */
	setUrl : function (url) {
		return this._url = url.toString();
	},
	
	setTimeout : function (timeout) {
		this._timeout = timeout;
	},
  
	/**
	 * @private
	 */
	_buildUrl : function () {
		var paramsStr = "";
		for(var key in this._params) {
			var paramValue = this._params[key];
			if (typeof(paramValue) == "object" && paramValue.constructor == Array) {
				for(var valueKey in paramValue) {
					paramsStr += key + "[]=" + encodeURI(paramValue[valueKey]) + "&";
				}
			} else {
				paramsStr += key + "=" + encodeURI(paramValue) + "&";
			}
		}
		if (this._requestMethod == DHttpRequest.GET_REQUEST) {
			var parser = new DSerializer(this._dataType);
			var dataStr = parser.serialize(this._data);
			paramsStr += 'data=' + encodeURI(dataStr) + "&";
		}
		var joinSymbol = '?';
		if (this._url.search(/\?/) != -1) {
			joinSymbol = '&';
		}
		return this._url + joinSymbol + paramsStr + "uniq=" + (new Date()).getTime();
	},

	/**
	 * Builds POST data.
	 * @private
	 */
	_buildPostData : function() {
		var postStr = "";
		if (this._data != null) {
			var formatter = new DSerializer(this._dataType);
			postStr = formatter.serialize(this._data);
		} else {
			for (var par in this._postParams) {
				postStr += par + "=" + encodeURI(this._postParams[par]) + "&";
			}
			if (postStr != "") {
				postStr = postStr.substr(0, postStr.length - 1);
			}
		}
		return postStr;
	},

	/**
	 * Sends the requires to the server. It executes the callback 
	 * function when the answer is recieved.
	 */
	send : function () {
		switch (this._mode) {
			case DHttpRequest.XMLHTTP_MODE:
				return this._sendXmlHttp();
			case DHttpRequest.IFRAME_MODE:
				return this._sendIFrame();
		}
	},

	/**
	 * @private
	 */
	_sendXmlHttp : function () {
		var request = this._request;
		if (request && request.readyState != 0) {
			request.abort();
		}
		request = this._request = this.getXmlHttpRequest();
		if (request) {
			this._requestKey++;
			setTimeout("DHttpRequest.registry[" + this._key + "]._abort(" + this._requestKey + ");", this._timeout);
			request.open(this._requestMethod, this._buildUrl(), true);
			if (this._requestMethod == DHttpRequest.POST_REQUEST) {
				request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
			//request.send(this._buildPostData());
			}
			var _this = this;
			request.onreadystatechange = function () {
				_this._readyState = request.readyState;
				_this._listeners.notify("OnReadyStateChange");
				if (request.readyState == DHttpRequest.COMPLETED) {
					try {
						var parser = new DSerializer(this._dataType);
						var data = parser.unserialize(request.responseText);
						_this._setData(data);
					} catch(e) {
						if ("undefined" != typeof(_toLog)) {
							_toLog(e.toString());
							_toLog(data);
							_toLog("Ajax request returns wrong data.");
						}
					}
				}
			};
			request.send(this._buildPostData());
		}
	},

	/**
	 * @private
	 */
	_sendIFrame : function () {
		this._request.contentWindow.location = this._buildUrl();
	},
  
	/**
	 * @private
	 */
	_setData : function (data) {
		if (data.ccserror) {
			this._listeners.notify("OnError", data.ccserror);
		} else {
			this._listeners.notify("OnSuccess", data);
			this._listeners.notify("OnDataAvailable", data);
		}
	}

};

/**
 * @constructor
 */
function DAutoFillModel() {
	this._dataSource = null;
	this._items = new Array();
	this._itemsKey = "";
	DEventListeners.support(this);
}

DAutoFillModel.prototype = {

	setDataSource : function (dataSource) {
		this._dataSource = dataSource;
		var _this = this;
		this._dataSource.addListener('OnDataRequestComplete', function (e) {
			_this._itemsKey = e.args.key;
			_this.setItems(e.args.data);
			
		});
	},

	getDataSource : function () {
		return this._dataSource;
	},
	
	setItems : function (items) {
		this._items = items;//new Array();
		/*for (var j = 0; j < items.length; j++) {
			this._items[j] = new Array();
			this._items[j][0] = items[j][0];
			this._items[j][1] = items[j][1];
			//for (var i = 0; i < items[j].length; i+=2) {
				//this._items[j][items[j][i]] = items[j][i+1];
			//}
		}*/
		this._listeners.notify('OnChangeItems');
	}
}

/**
 * @constructor
 */
function DAutoFillView (model) {
	DEventListeners.support(this);
	this._model = model;
	// Regular controls
	this._bindings = new Array();
	this._fields = new Array();
	this._properties = new Array();
	// Lists
	this._lists = new Array();
	this._boundColumns = new Array();
	this._textColumns = new Array();
}

DAutoFillView.prototype = {

	/**
	 * Sets bound control.
	 */ 
	setControlBinding : function (control, field, property) {
		this._bindings[this._bindings.length] = control;
		this._fields[this._fields.length] = field;
		this._properties[this._properties.length] = property;
	},

	/**
	 * Sets bound listbox, it's options property will be filled with data.
	 */
	setListBinding : function (control, bound_column, text_column) {
		this._lists[this._lists.length] = control;
		this._boundColumns[this._boundColumns.length] = bound_column;
		this._textColumns[this._textColumns.length] = text_column;
	},

	/**
	 * This method initiates data retrieval and bound control filling.
	 */
	request : function (value) {
		this._model.getDataSource().request(value);
		var _this = this;
		this._model._listeners["OnChangeItems"] = new Array();
		this._model.addListener("OnChangeItems", function (e) {
			_this._listeners.notify("OnRequestComplete");
			for(var i = 0; i < _this._bindings.length; i++) {
				var control = _this._bindings[i];
				control[_this._properties[i]] = _this._model._items[0][_this._fields[i]];
			}
			for (var j = 0; j < _this._lists.length; j++) {
				var list = _this._lists[j];
				if (list.options.item(0).value == "") {
					list.options.length = 1;
				} else {
					list.options.length = 0;
				}
				for (var k = 0; k < _this._model._items.length; k++) {
					var option = new Option();
					option.value = _this._model._items[k][_this._boundColumns[j]];
					option.text = _this._model._items[k][_this._textColumns[j]];
					list.options.add(option);
				}
			}
		});
	}
};

/**
 * @constructor
 */
function DCommon() {};

DCommon.initAutocomplete = function(pageName, featureName, control) {
	var model = new DAutocompleteModel();
	var ds = new DAjaxDataSource(pageName + "?callbackControl=" + featureName);
	ds.setData(control["ccs"+featureName+"Data"]);
    model.setDataSource(ds);
    var view = new DAutocompleteView(model);
    view.setControl(control);
    view.draw();
};

DCommon.initDependantListBox = function(pageName, featureName, masterControl, dependantControl, boundColumn, textColumn) {
	if (boundColumn == "") {
		boundColumn = "0";
	}
	if (textColumn == "") {
		textColumn = "1";
	}
	var model = new DAutoFillModel();
	var ds = new DAjaxDataSource(pageName + "?callbackControl=" + featureName);
	ds.setData(dependantControl["ccs"+featureName+"Data"]);
    model.setDataSource(ds);
    var view = new DAutoFillView(model);
	DHtmlHelper.addEventHandler(masterControl, 'change', function () {
    	view.request(masterControl.value);
    });
	view.setListBinding(dependantControl, boundColumn, textColumn);
	return ds;
};

DCommon.initAutoFill = function(pageName, featureName, masterControl, controlsCollection) {
	var model = new DAutoFillModel();
	var ds = new DAjaxDataSource(pageName + "?callbackControl=" + featureName);
	ds.setData(masterControl["ccs"+featureName+"Data"]);
    model.setDataSource(ds);
    var view = new DAutoFillView(model);
    DHtmlHelper.addEventHandler(masterControl, 'change', function () {
        view.request(masterControl.value);
    });
    for (var i = 0; i < controlsCollection.length; i++) {
    	var currentControl = controlsCollection[i];
    	view.setControlBinding(currentControl[0], currentControl[1], currentControl[2]);
    }
};

DCommon.CCSetCookie = function(name,value,days) {
	if (days)
	{
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "; expires="+date.toGMTString();
	}
	else var expires = "";
	document.cookie = name+"="+value+expires+"; path=/";
};

DCommon.CCGetCookie = function(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++)
	{
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
};

DCommon.CCDeleteCookie = function(name) {
	DCommon.CCSetCookie(name,"",-1);
};

DCommon.CCGetParam = function(strParamName) {
	var strReturn = "";
	var strHref = window.location.href;
	if ( strHref.indexOf("?") > -1 ) {
		var strQueryString = strHref.substr(strHref.indexOf("?")).toLowerCase();
		var aQueryString = strQueryString.split("&");
		for ( var iParam = 0; iParam < aQueryString.length; iParam++ ) {
			if (aQueryString[iParam].indexOf(strParamName + "=") > -1 ) {
				var aParam = aQueryString[iParam].split("=");
				strReturn = aParam[1];
				break;
			}
		}
	}
	return strReturn;
};