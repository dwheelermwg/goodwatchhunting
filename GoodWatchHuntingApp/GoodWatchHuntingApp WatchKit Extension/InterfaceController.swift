//
//  InterfaceController.swift
//  GoodWatchHuntingApp WatchKit Extension
//
//  Created by Derek Wheeler on 12/9/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import WatchKit
import Foundation
import HealthKit


class InterfaceController: WKInterfaceController {
    let surveyor = HealthSurveyor()

    override func awakeWithContext(context: AnyObject?) {
        super.awakeWithContext(context)
        // Configure interface objects here.
        
        
    }
    
    @IBAction func startSurvey() {
        self.surveyor.startSurvey();
    }
    
    @IBAction func stopSurvey() {
        self.surveyor.stopSurvey()
    }

    override func willActivate() {        
        // This method is called when watch view controller is about to be visible to user
        super.willActivate()
    }

    override func didDeactivate() {
        // This method is called when watch view controller is no longer visible
        super.didDeactivate()
    }
}
