class Main extends React.Component{
    constructor(props) 
    {
     super(props);
     this.state=
     {
       title: this.props.title,
       palindrom: null,
     };
    } 
    render()
    {
      return(
       <div>
          <h1>
          {this.state.title}
          </h1>
          <h2>
          {this.props.subtitle}
          </h2>
          {this.state.palindrom ? "Palindrom" : "Not palindrom"}
          <p>
          {this.props.article}
          </p>
        <button onClick={ () => this.palindromCheck(this.props.subtitle.toLowerCase())} >Palindrom check</button>
          <button onClick={ () => this.reverseText(this.state.title)} >Odwróæ wyraz</button>
        </div>
        );
    }
   palindromCheck(tekst)
   {
     for(var i=0; i<tekst.length; i++)
       {
         if(tekst[i]==tekst[tekst.length-1-i])
           {
             continue;
           }
         else
           {
             this.setState({palindrom: false});
             return;
           }
       }
     this.setState({palindrom: true});
   }
   reverseText(tekst)
   {
     var temp=[];
     var i=tekst.length-1;
     while(i>=0)
     {
       temp.push(tekst[i]);
       i--;
     }
     console.log(tekst);
     console.log(temp.join(""));
     this.setState({title: temp});
   }
 };
 
 
 
 ReactDOM.render( <Main title="Naglowek" subtitle="LowOl" article="Lorem ipsum" />,
   document.getElementById('root')
 );
 