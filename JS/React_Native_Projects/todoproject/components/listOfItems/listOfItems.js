import React from 'react'
import { StyleSheet } from 'react-native'
import { List, ListItem, Text, Button, ActionSheet } from 'native-base'
import SingleItem from '../singleItem/singleItem'

export default class ListOfItems extends React.Component {

  // --- Render ---
  render() {

    // --- Props ---
    const { title, listItems, clearItems } = this.props
    

    // --- Header & ActionSheet ---
    // action sheet
    let actionSheetOptions = ['Clear All Tasks', 'Cancel']

    // conditional header
    let listHeader
    if (title) {

      listHeader = listItems.length > 0 ? 
        <Text>{title}</Text> :
        <Text>No active tasks</Text>

    } else if (!title && listItems.length > 0) {

      listHeader = (
        <Button small transparent danger onPress={() =>
          ActionSheet.show(
            {
              options: actionSheetOptions,
              cancelButtonIndex: actionSheetOptions[1],
              destructiveButtonIndex: actionSheetOptions[0],
              title: 'Clear all complete tasks?'
            },
            buttonIndex => { 
              if (buttonIndex === 0) clearItems() 
            }
          )} >
          <Text>Clear All</Text>
        </Button>
      )
    } else listHeader = <Text>No completed tasks</Text>


    // --- Display ---
    return (
      <List>
        <ListItem itemHeader first>
          {listHeader}
        </ListItem>

        <List dataArray={listItems} 
          renderRow={item => 
            <SingleItem 
              item={item} 
              title={title} /> 
          }>
        </List>
      </List>
    )
  }
}
