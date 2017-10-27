import React from 'react'
import { AsyncStorage } from 'react-native'
import { Container, Content } from 'native-base'
import ListOfItems from '../../components/listOfItems/listOfItems'

export default class Complete extends React.Component {

  // --- Constuctor ---
  constructor(props) {
    super(props)
    this.state = { completedItems: [] }
  }


  // --- LifeCycle ---
  // initial
  componentWillMount() {
    this.getCompletedTodos()
      .then(res => { 
        if (res) this.displayCompletedItems(JSON.parse(res)) 
      })
  }

  // on tab show
  componentWillReceiveProps() {
    this.getCompletedTodos()
      .then(res => {
        if (res) this.displayCompletedItems(JSON.parse(res))
      })
  }


  // --- AsyncStorage ---
  // get 
  getCompletedTodos = () => AsyncStorage.getItem('completedItems')

  // clear all
  clearCompletedTodos = () => AsyncStorage.removeItem('completedItems')

  // clear single
  clearSingleTask = key => {

    // update state
    this.setState({
      completedItems: this.state.completedItems.filter(x => x.id !== key)
    }, () => {

      // update async storage
      AsyncStorage.setItem('completedItems', JSON.stringify(this.state.completedItems))
    })
  }


  // --- Completed Items ---
  // display
  displayCompletedItems = items => {
    items.forEach(x => { x.removeSingle = this.clearSingleTask })
    this.setState({
      completedItems: items.sort((a, b) => (Date.parse(a.date) / 100) - (Date.parse(b.date) / 100))
    })
  }

  // clear all
  clearAllCompleteItems = () => {
    this.setState({ completedItems: [] }, 
      () => this.clearCompletedTodos())
  }

  // --- Render ---
  render() {
    return (
      <Container>
        <Content>
          <ListOfItems 
            listItems={this.state.completedItems} 
            clearItems={this.clearAllCompleteItems}
            title={''} />
        </Content>
      </Container>
    )
  }
}