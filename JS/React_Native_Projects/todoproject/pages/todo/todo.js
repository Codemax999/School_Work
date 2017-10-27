import React from 'react'
import { AsyncStorage } from 'react-native'
import { Container, Content } from 'native-base'
import NewItem from '../../components/newItem/newItem'
import ListOfItems from '../../components/listOfItems/listOfItems'

export default class Todo extends React.Component {

  // --- Constructor ----
  constructor(props) {
    super(props)
    this.state = { activeItems: [] }
  }


  // --- LifeCycle ---
  // initial
  componentWillMount() {
    this.getLocalTodo()
      .then(res => {
        if (res) this.displayToDoItems(JSON.parse(res))
      })
  }

  // on tab show
  componentWillReceiveProps() {
    this.getLocalTodo()
      .then(res => {
        if (res) this.displayToDoItems(JSON.parse(res))
      })
  }


  // --- Display ---
  displayToDoItems = items => {
    items.forEach(x => x.removeItem = this.handleRemoveItem)
    this.setState(prevState => ({
      activeItems: items.sort((a, b) => (Date.parse(a.date) / 100) - (Date.parse(b.date) / 100))
    }))
  }


  // --- ToDo Item ---
  // add
  handleAddItem = newItem => {

    // add index and remove item method 
    newItem.id = this.state.activeItems.length
    newItem.removeItem = this.handleRemoveItem

    // update state
    this.setState(prevState => ({
      activeItems: [...prevState.activeItems, newItem]
        .sort((a, b) => (Date.parse(a.date) / 100) - (Date.parse(b.date) / 100))
    }), () => {

      // get previously saved items
      this.getLocalTodo()
        .then(res => {

          // save updated array of items
          let previousItems = !!res ? JSON.parse(res) : []
          const toDoItems = [...previousItems, newItem]
          this.setLocalToDo(toDoItems)
        })
    })
  }

  // remove
  handleRemoveItem = key => {

    this.setState(prevState => ({
      activeItems: [...prevState.activeItems].filter((x, i) => x.id !== key)
    }), () => {

      // get previously saved items
      this.getLocalTodo()
        .then(res => {

          // filter out by id
          const updatedItems = JSON.parse(res).filter((x, i) => x.id !== key)
          this.setLocalToDo(updatedItems)
        })
    })
  }
  

  // --- LocalStorage ---
  // get
  getLocalTodo = () => AsyncStorage.getItem('toDoItems')

  // set
  setLocalToDo = newItems => AsyncStorage.setItem('toDoItems', JSON.stringify(newItems))


  // --- Render ---
  render() {
    return (
      <Container>
        <Content>
          <NewItem onAddItem={this.handleAddItem} />
          <ListOfItems 
            listItems={this.state.activeItems} 
            title={'Active'} />
        </Content>
      </Container>
    )
  }
}
