import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div className="hero min-h-screen" style={{backgroundImage: 'url(https://daisyui.com/images/stock/photo-1507358522600-9f71e620c44e.jpg)'}}>
        <div className="hero-overlay bg-opacity-60"></div>
        <div className="hero-content text-center text-neutral-content">
          <div className="max-w-md">
            <p className="mb-5 text-2xl">展放愁眉，休争闲气。今日容颜，老于昨日。古往今来，尽须如此，管他贤的愚的，贫的和富的。到头这一身，难逃那一日。受用了一朝，一朝便宜。百岁光阴，七十者稀。急急流年，滔滔逝水。</p>
          </div>
        </div>
      </div>
    );
  }
}
