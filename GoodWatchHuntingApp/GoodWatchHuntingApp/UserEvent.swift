//
//  UserEvent.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/10/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import Foundation
import SwiftyJSON

class UserEvent {
    var userId: String
    var eventId: String
    var initialHealthRecord: HealthRecord
    var averageHealthRecord: HealthRecord
    var finalHealthRecord: HealthRecord
    var startTime: String
    var endTime: String
    
    init() {
        self.userId = ""
        self.eventId = ""
        self.initialHealthRecord = HealthRecord()
        self.averageHealthRecord = HealthRecord()
        self.finalHealthRecord = HealthRecord()
        self.startTime = ""
        self.endTime = ""
    }
}