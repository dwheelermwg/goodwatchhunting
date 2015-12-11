//
//  HealthRecord.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/10/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import Foundation
import SwiftyJSON

class HealthRecord {
    var time: String?
    var heartRate: Double?
    var bodyTemp: Double?
    var bloodPressure: String?
    var respitoryRate: Int?
    var stepCount: Int?
    
    init() {
        self.time = ""
        self.heartRate = 0.0
        self.bodyTemp = 0.0
        self.bloodPressure = ""
        self.respitoryRate = -1
        self.stepCount = -1
    }
    
    init(time: String, heartRate: Double, bodyTemp: Double, bloodPressure: String, respitoryRate:Int, stepCount: Int) {
        self.time = time
        self.heartRate = heartRate
        self.bodyTemp = bodyTemp
        self.bloodPressure = bloodPressure
        self.respitoryRate = respitoryRate
        self.stepCount = stepCount
    }
}