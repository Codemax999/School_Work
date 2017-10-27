import React from 'react'
import { StyleSheet, AsyncStorage } from 'react-native'
import { Text, Left, Right, Icon, Card, CardItem, Button } from 'native-base'

export default class SingleItem extends React.Component {

  // --- ToDo List ---
  // remove (todo page)
  removeSingleItem = () => this.props.item.removeItem(this.props.item.id)

  // remove (complete page)
  removeFromComplete = () => this.props.item.removeSingle(this.props.item.id)

  // complete todo
  completeSingleItem = () => {

    // get previous items array
    AsyncStorage.getItem('completedItems')
      .then(res => {
        
        // save updated aray of items
        let previousItems = !!res ? JSON.parse(res) : []
        const completedItems = [...previousItems, this.props.item]
        AsyncStorage.setItem('completedItems', JSON.stringify(completedItems))

        // remove item from todo list
        this.removeSingleItem()
      })
  }


  // --- Render ---
  render() {

    // --- Props ---
    const { title, item } = this.props


    // clear and complete buttons
    let btnLeft, btnRight
    
    if (title) {

      btnRight = (
        <Right>
          <Button transparent success onPress={this.completeSingleItem}>
            <Icon name="ios-checkmark-circle-outline" />
            <Text>Complete</Text>
          </Button>
        </Right>
      )
    }

    // Remove item (todo and complete)
    let removeItem = title ? this.removeSingleItem : this.removeFromComplete
    btnLeft = (
      <Left>
        <Button transparent danger onPress={removeItem}>
          <Icon name="ios-remove-circle-outline" />
          <Text>Remove</Text>
        </Button>
      </Left>
    )

    return (
      <Card key={item.id} style={styles.card}>

        <CardItem header>
          <Text style={styles.cardHeaderText}>
            {item.date}
          </Text>
        </CardItem>

        <CardItem>
          <Text style={styles.cardBodyText}>
            {item.description}
          </Text>
        </CardItem>

        <CardItem style={styles.actionBtns}>
          {btnLeft}
          {btnRight}
        </CardItem>
      </Card>
    )
  }
}

const styles = StyleSheet.create({
  card: {
    display: 'flex',
    height: 165,
    flexDirection: 'column',
    position: 'relative'
  },
  cardHeaderText: {
    color: '#424242',
    fontSize: 14
  },
  cardBodyText: {
    fontSize: 18,
    letterSpacing: .8
  },
  actionBtns: {
    bottom: 0,
    position: 'absolute',
    width: '100%'
  }
})
