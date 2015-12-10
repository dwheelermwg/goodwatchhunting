//
//  GoodWatchEvent.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/10/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import Foundation
import SwiftyJSON

class GoodWatchEvent {
    enum EventType {
        case Physical
        case ScavengerHunt
        case Location
    }
    
    var id:String
    var type:Int
    var name:String
    var message:String?
    var goal:String?
    
    init() {
        id = ""
        type = -1
        name = ""
        message = ""
        goal = ""
    }
    
    init(json: JSON) {
        
    }
}